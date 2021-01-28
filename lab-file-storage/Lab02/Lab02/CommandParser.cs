using Lab02.Commands;
using System;

namespace Lab02
{
    internal class CommandParser
    {
        internal static ICommand Parse(string[] args)
        {
            if (args.Length < 2)
            {
                throw new FormatException("Boss, it's fiasco.");
            };
            string commandName = args[1] + args[0];
            Type type = Type.GetType($"Lab02.Commands.{commandName}", true, true);
            ICommand parsedCommand = (ICommand)Activator.CreateInstance(type);
            for (int i = 2; i < args.Length; i++)
            {
                parsedCommand.Options.Add(args[i]);
            }
            return parsedCommand;
        }
    }
}
