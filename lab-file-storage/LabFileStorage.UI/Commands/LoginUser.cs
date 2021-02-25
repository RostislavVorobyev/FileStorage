using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace LabFileStorage.UI.Commands
{
    internal class LoginUser : ICommand
    {
        private readonly string _login;
        private readonly string _password;
        private readonly List<string> _options;

        public LoginUser(string login, string password, List<string> options)
        {
            _login = login;
            _password = password;
            _options = options;
        }

        public string Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid login command arguments.");
            }

            string login = _options[1];
            string password = _options[3];
            CheckLoginAndPassword(login, password);

            return "Succsess";
        }

        private void CheckLoginAndPassword(string login, string password)
        {
            if (!(login == _login && password == _password))
            {
                throw new Exception("Wrong login or password");
            }
        }

        private bool OptionsAreValid()
        {
            return _options.Count == 4 && _options[0] == "--l" && _options[2] == "--p";
        }
    }
}
