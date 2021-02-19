using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util
{
    abstract class CommandLineParser
    {
        internal abstract ICommand Parse(string userInput);

        protected string[] SplitInputArguments(string userInput)
        {
            userInput = userInput.Trim();
            string[] inputArguments = Regex.Split(userInput, @"\s+");
            if (inputArguments.Length < 2)
            {
                throw new Exception("Illegal command input.");
            }

            return inputArguments;
        }

        protected List<string> ParseCommandOptions(string[] inputArguments)
        {
            List<string> options = new List<string>();
            for (int i = 2; i < inputArguments.Length; i++)
            {
                options.Add(inputArguments[i]);
            }

            return options;
        }

    }
}
