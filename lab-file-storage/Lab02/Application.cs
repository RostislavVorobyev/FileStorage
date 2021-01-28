using Lab02.Commands;
using System;

namespace Lab02
{
    public class Application
    {
        private static bool isAuthorized;

        public static void Main(string[] args)
        {
            Console.WriteLine("Runned");
            Authorize();
        }

        private static void Authorize()
        {
            while (!isAuthorized)
            {
                Console.WriteLine("Authorize to use the programm.");
                string command = Console.ReadLine();
                ICommand authorization = CommandParser.Parse(command.Split(" "));
                if (authorization?.GetType() == Type.GetType("Lab02.Commands.LoginUser"))
                {
                    isAuthorized = authorization.Execute();
                }
            }
        }

        private static void ReadMetaInformation()
        {
            throw new NotImplementedException();
        }
    }
}
