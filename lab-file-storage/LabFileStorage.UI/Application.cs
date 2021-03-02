using System;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Context;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using LabFileStorage.UI.Util;
using LabFileStorage.UI.Util.Parser;
using Microsoft.EntityFrameworkCore;
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
            //Authorize(authorizeParser);
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
            string storagePath = ConfigProvider.GetStoragePath();
            string connectionString = ConfigProvider.GetMSSQLConnectionString();
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<IFileRepository>(c => new FileRepository(storagePath))
                .AddScoped<IMetaInformationRepository>(c => new MetadataDBRepository(new ApplicationDbContext(connectionString)))
                .AddScoped<IFileService, FileService>(c => new FileService(c.GetService<IFileRepository>(), c.GetService<IMetaInformationRepository>(), storagePath))
                .AddSingleton<FileCommandParser>()
                .AddSingleton(c => new AuthorizeCommandParser(ConfigProvider.GetLogin(), ConfigProvider.GetPassword()))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}


