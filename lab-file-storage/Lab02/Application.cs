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
            string command = Console.ReadLine();
            
            ICommand authorization = CommandParser.Parse(command.Split(" "));
            authorization.Execute();
            

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
                    }
                    catch (AuthenticationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
        }

    }
}

