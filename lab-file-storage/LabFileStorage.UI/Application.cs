using System;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.Common;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using LabFileStorage.UI.Util.Parser;
using Microsoft.Extensions.DependencyInjection;


namespace LabFileStorage.UI
{
    public class Application
    {
        public static void Main()
        {
            ServiceProvider _serviceProvider = ConfigureServiceProvider();
            FileCommandParser commandParser = _serviceProvider.GetRequiredService<FileCommandParser>();
            AuthorizeCommandParser authorizeParser = _serviceProvider.GetRequiredService<AuthorizeCommandParser>();
            Console.WriteLine("Runned");
            Authorize(authorizeParser);
            while (true)
            {
                ReadUserCommand(commandParser);
            }
        }

        private static void Authorize(AuthorizeCommandParser authorizeParser)
        {
            Console.WriteLine("Authorize to use the program.");
            {
                try
                {
                    HandleInput(authorizeParser);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Authorize(authorizeParser);
                }
            }
        }

        private static void ReadUserCommand(FileCommandParser commandParser)
        {
            Console.WriteLine("Input your command:");
            try
            {
                HandleInput(commandParser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void HandleInput(CommandLineParser parser)
        {
            string userInput = Console.ReadLine();
            ICommand command = parser.Parse(userInput);
            string commandResult = command.Execute();
            if (commandResult != null)
            {
                Console.WriteLine(commandResult);
            }
        }

        internal static ServiceProvider ConfigureServiceProvider()
        {
            string connectionString = ConfigProvider.GetStoragePath();
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped(c => BuildFileRepository(connectionString))
                .AddScoped(c => BuildMetaRepository(connectionString))
                .AddScoped<IFileService, FileService>()
                .AddSingleton<FileCommandParser>()
                .AddSingleton<AuthorizeCommandParser>()
                .BuildServiceProvider();

            return serviceProvider;
        }

        private static IFileRepository BuildFileRepository (string storage)
        {
            return new FileRepository(storage);
        }

        private static IMetaInformationRepository BuildMetaRepository(string storage)
        {
            return new MetaInformationRepository(storage);
        }
    }
}


