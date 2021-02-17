using LabFileStorage.UI.Util;
using System.Collections.Generic;
using System.Security.Authentication;

namespace LabFileStorage.UI.Commands
{
    internal class LoginUser : ICommand
    {
        private readonly string _login;
        private readonly string _password;
        private bool _isSucceeded;

        public LoginUser()
        {
            _login = ConfigLoader.GetConfiguration()["Login"];
            _password = ConfigLoader.GetConfiguration()["Password"];
        }

        public List<string> Options { get; } = new List<string>();

        public string ResultMessage { get; set; }

        public bool Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid login command arguments.");
            }
            string login = Options[1];
            string password = Options[3];
            _isSucceeded = login == _login && password == _password;
            return _isSucceeded;
        }

        private bool OptionsAreValid()
        {
            return Options.Count == 4 && Options[0] == "--l" && Options[2] == "--p";
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? "Success" : "Wrong login or password";
            return resultMessage;
        }
    }
}
