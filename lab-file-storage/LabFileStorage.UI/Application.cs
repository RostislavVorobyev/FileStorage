using System;
using System.Security.Authentication;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using LabFileStorage.UI.Util;
using Microsoft.Extensions.DependencyInjection;

namespace LabFileStorage.UI
{
    public class Application
    {
        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IFileRepository, FileRepository>()
            .BuildServiceProvider();

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
                        Console.WriteLine(authorization.ResultMessage);
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
                if (authorization?.ResultMessage != null)
                {
                    Console.WriteLine(authorization.ResultMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

