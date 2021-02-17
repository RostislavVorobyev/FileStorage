using System.Collections.Generic;
using System.Security.Authentication;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Util;

namespace LabFileStorage.UI.Commands
{
    internal class LoginUser : ICommand
    {
        private readonly string _login;
        private readonly string _password;

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
            bool isAuthorized = login == _login && password == _password;
            ResultMessage = isAuthorized ? "Success" : "Wrong login or password";
            return login == _login && password == _password;
        }

        private bool OptionsAreValid()
        {
            return Options.Count == 4 && Options[0] == "--l" && Options[2] == "--p";
        }
    }
}
