using System;
using System.Collections.Generic;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util
{
    internal class AuthorizeCommandParser : CommandLineParser
    {
        private const string userLoginCommand = "user login";

        internal override ICommand Parse(string userInput)
        {
            string[] inputArguments = SplitInputArguments(userInput);
            string commandName = $"{inputArguments[0]} {inputArguments[1]}".ToLower();
            List<string> commandOptions = ParseCommandOptions(inputArguments);
            switch (commandName)
            {
                case userLoginCommand: return new LoginUser(commandOptions);
                default: throw new Exception("Use user login --l <login> --p <password> to log in.");
            }
        }
    }
}
