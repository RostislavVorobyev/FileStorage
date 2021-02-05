using System;
using System.Collections.Generic;
using System.Security.Authentication;

namespace Lab02.Commands
{
    public class LoginUser : ICommand
    {
        public List<string> Options { get; }
        private readonly string _login;
        private readonly string _password;
         
        public LoginUser()
        {
            Options = new List<string>();
            _login = ConfigLoader.GetConfiguration()["Login"];
            _password = ConfigLoader.GetConfiguration()["Password"];
        }

        public bool Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid command arguments.");
            }
            string login = Options[1];
            string password = Options[3];
            return login == _login && password == _password;
        }

        private bool OptionsAreValid()
        {
            return Options.Count == 4 && Options[0] == "--l" && Options[2] == "--p";
        }
    }
}
