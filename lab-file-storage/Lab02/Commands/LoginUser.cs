﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Authentication;
using System.Text;

namespace Lab02.Commands
{
    public class LoginUser : ICommand
    {
        public List<string> Options { get; }
        private readonly string login;
        private readonly string password;

        public LoginUser()
        {
            Options = new List<string>();
            login = ConfigLoader.GetConfiguration()["Login"];
            password = ConfigLoader.GetConfiguration()["Password"];
        }

        public bool Execute()
        {
            if (!OptionsAreValid())
            {
                throw new AuthenticationException("Invalid command arguments.");
            }
            string login = Options[1];
            string password = Options[3];
            return login == this.login && password == this.password;
        }

        private bool OptionsAreValid()
        {
            return Options.Count == 4 && Options[0] == "--l" && Options[2] == "--p";
        }
    }
}
