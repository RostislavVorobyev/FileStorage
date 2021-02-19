using System;
using System.Collections.Generic;
using System.Security.Authentication;
using LabFileStorage.UI.Util;

namespace LabFileStorage.UI.Commands
{
    internal class LoginUser : ICommand
    {
        private readonly string _login;
        private readonly string _password;
        private readonly List<string> _options;

        public LoginUser(List<string> options)
        {
            _login = ConfigLoader.GetConfiguration()["Login"];
            _password = ConfigLoader.GetConfiguration()["Password"];
            _options = options;
        }

        public string ResultMessage { get; set; }

        public string Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid login command arguments.");
            }
            string login = _options[1];
            string password = _options[3];
            if (login == _login && password == _password)
            {
                return "Success";
            }
            throw new Exception("Wrong login or password");
        }

        private bool OptionsAreValid()
        {
            return _options.Count == 4 && _options[0] == "--l" && _options[2] == "--p";
        }
    }
}
