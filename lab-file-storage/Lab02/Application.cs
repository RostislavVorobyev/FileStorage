using System;
using Lab02.Commands;
using System.Security.Authentication;

namespace Lab02
{
    public class Application
    {
        public static void Main()
        {
            Console.WriteLine("Runned");
            Authorize();
            while (true)
            {
                ReadUserCommand();
            }
        }

        private static void Authorize()
        {
            bool isAuthorized = false;
            while (!isAuthorized)
            {
                Console.WriteLine("Authorize to use the programm.");
                string command = Console.ReadLine();
                ICommand authorization = CommandParser.Parse(command.Split(" "));
                if (authorization?.GetType() == typeof(LoginUser))
                {
                    try
                    {
                        isAuthorized = authorization.Execute();
                        Console.WriteLine(authorization.GetResultMessage());
                    }
                    catch (AuthenticationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private static void ReadUserCommand()
        {
            Console.WriteLine("Input your command:");
            try
            {
                string command = Console.ReadLine();
                ICommand authorization = CommandParser.Parse(command.Split(" "));
                authorization?.Execute();
                if (authorization?.GetResultMessage() != null)
                {
                    Console.WriteLine(authorization.GetResultMessage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

