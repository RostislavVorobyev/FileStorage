using System;
using System.Collections.Generic;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util.Parser
{
    internal class AuthorizeCommandParser : CommandLineParser
    {
        private readonly string _login;
        private readonly string _password;
        public AuthorizeCommandParser(string login, string password)
        {
            _login = login;
            _password = password;
        }

        internal override ICommand Parse(string userInput)
        {
            string[] inputArguments = SplitInputArguments(userInput);
            string commandName = $"{inputArguments[0]} {inputArguments[1]}".ToLower();
            List<string> commandOptions = ParseCommandOptions(inputArguments);
            switch (commandName)
            {
                case SupportedCommandConstants.UserLogin: return new LoginUser(_login, _password, commandOptions);
                default: throw new Exception("Use user login --l <login> --p <password> to log in.");
            }
        }
    }
}
