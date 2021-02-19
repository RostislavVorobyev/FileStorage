using System;
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
        static FileCommandParser parser;
        static AuthorizeCommandParser authParser;
        public static void Main()
        {
            ServiceProvider serviceProvider = ConfigureServiceProvider();
            parser = serviceProvider.GetRequiredService<FileCommandParser>();
            authParser = serviceProvider.GetRequiredService<AuthorizeCommandParser>();
            Console.WriteLine("Runned");
            Authorize();
            while (true)
            {
                ReadUserCommand();
            }
        }

        private static void Authorize()
        {
            Console.WriteLine("Authorize to use the programm.");
            {
                try
                {
                    string userInput = Console.ReadLine();
                    ICommand authorizationCommand = authParser.Parse(userInput);
                    string authiorizationResult = authorizationCommand.Execute();
                    Console.WriteLine(authiorizationResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Authorize();
                }
            }
        }

        private static void ReadUserCommand()
        {
            Console.WriteLine("Input your command:");
            try
            {
                string userInput = Console.ReadLine();
                ICommand command = parser.Parse(userInput);
                string commandResult = command.Execute();
                if (commandResult != null)
                {
                    Console.WriteLine(commandResult);
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
                .AddSingleton<FileCommandParser>()
                .AddSingleton<AuthorizeCommandParser>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}

