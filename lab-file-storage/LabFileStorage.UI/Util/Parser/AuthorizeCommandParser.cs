using System;
using System.Collections.Generic;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util.Parser
{
    internal class AuthorizeCommandParser : CommandLineParser
    {

        internal override ICommand Parse(string userInput)
        {
            string[] inputArguments = SplitInputArguments(userInput);
            string commandName = $"{inputArguments[0]} {inputArguments[1]}".ToLower();
            List<string> commandOptions = ParseCommandOptions(inputArguments);
            switch (commandName)
            {
                case SupportedCommandConstants.UserLogin: return new LoginUser(commandOptions);
                default: throw new Exception("Use user login --l <login> --p <password> to log in.");
            }
        }
    }
}
