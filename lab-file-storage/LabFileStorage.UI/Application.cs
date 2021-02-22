using System;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using LabFileStorage.UI.Util.Parser;
using Microsoft.Extensions.DependencyInjection;


namespace LabFileStorage.UI
{
    public class Application
    {
        private static readonly ServiceProvider _serviceProvider = ConfigureServiceProvider();

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
            Console.WriteLine("Authorize to use the programm.");
            {
                try
                {
                    HandleInput(_serviceProvider.GetRequiredService<AuthorizeCommandParser>());
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
                HandleInput(_serviceProvider.GetRequiredService<FileCommandParser>());
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
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<IFileRepository, FileRepository>()
                .AddScoped<IMetaInformationRepository, MetaInformationRepository>()
                .AddScoped<IFileService, FileService>()
                .AddSingleton<FileCommandParser>()
                .AddSingleton<AuthorizeCommandParser>()
                .BuildServiceProvider();
            return serviceProvider;
        }
    }
}

