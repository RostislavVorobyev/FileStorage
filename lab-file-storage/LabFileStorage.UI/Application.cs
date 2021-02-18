using System;
using System.Security.Authentication;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using LabFileStorage.UI.Util;
using Microsoft.Extensions.DependencyInjection;

namespace LabFileStorage.UI
{
    public class Application
    {
        static CommandParser parser;
        public static void Main()
        {
            ServiceProvider serviceProvider = ConfigureServiceProvider();
            parser = serviceProvider.GetRequiredService<CommandParser>();
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
                ICommand authorization = parser.Parse(command);
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
                ICommand authorization = parser.Parse(command);
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

        internal static ServiceProvider ConfigureServiceProvider()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IFileRepository, FileRepository>()
                .AddSingleton<IMetaInformationRepository, MetaInformationRepository>()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<CommandParser>()
                .BuildServiceProvider();
            return serviceProvider;
        }

    }
}

