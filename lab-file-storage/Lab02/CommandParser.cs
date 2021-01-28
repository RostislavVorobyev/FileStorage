using Lab02.Commands;
using System;

namespace Lab02
{
    internal class CommandParser
    {
        internal static ICommand Parse(string[] args)
        {
            try
            {
                return GetParsedCommand(args);
            }
            catch (Exception ex) when (ex is FormatException | ex is TypeLoadException)
            {
                Console.WriteLine("Non-existent command!");
            }
            return null;
        }

        private static ICommand GetParsedCommand(string[] args)
        {
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
