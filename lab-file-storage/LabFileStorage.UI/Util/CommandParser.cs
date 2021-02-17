using System;
using LabFileStorage.BLL.Services.Implementations;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Interfaces;
using LabFileStorage.UI.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace LabFileStorage.UI.Util
{
    internal static class CommandParser
    {
        static ServiceProvider Provider => GetServiceProvider();

        static internal ServiceProvider GetServiceProvider()
        {
            ServiceProvider serviceProvider = new ServiceCollection().
                AddSingleton<IFileRepository, FileRepository>().
                AddSingleton<IMetaInformationRepository, MetaInformationRepository>().
                AddSingleton<IFileService, FileService>().
                AddTransient<InfoFile>().
                AddTransient<DeleteFile>().
                AddTransient<DownloadFile>().
                AddTransient<InfoUser>().
                AddTransient<LoginUser>().
                AddTransient<MoveFile>().
                AddTransient<UploadFile>().
                BuildServiceProvider();
            return serviceProvider;
        }

        internal static ICommand Parse(string[] args)
        {
            try
            {
                return GetParsedCommand(args);
            }
            catch
            {
                Console.WriteLine("Non-existent command!");
            }
            return null;
        }

        private static ICommand GetParsedCommand(string[] args)
        {
            string commandName = args[1] + args[0];
            Type type = Type.GetType($"LabFileStorage.UI.Commands.{commandName}", true, true);
            ICommand parsedCommand = (ICommand)Provider.GetRequiredService(type);
            for (int i = 2; i < args.Length; i++)
            {
                parsedCommand.Options.Add(args[i]);
            }
            return parsedCommand;
        }

        
    }
}
