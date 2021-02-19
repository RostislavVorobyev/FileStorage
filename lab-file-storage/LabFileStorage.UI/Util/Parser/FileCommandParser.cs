using System;
using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util
{
    internal class FileCommandParser : CommandLineParser
    {
        private readonly IFileService _fileService;

        public FileCommandParser(IFileService fileService)
        {
            _fileService = fileService;
        }

        internal override ICommand Parse(string userInput)
        {
            string[] inputArguments = SplitInputArguments(userInput);
            string commandName = $"{inputArguments[0]}{inputArguments[1]}".ToLower();
            List<string> commandOptions = ParseCommandOptions(inputArguments);
            Enum.TryParse(commandName, true, out AvailableCommands command);
            ICommand parsedCommand;
            switch (command)
            {
                case AvailableCommands.FileDelete:
                    parsedCommand = new DeleteFile(_fileService, commandOptions);
                    break;
                case AvailableCommands.FileDownload:
                    parsedCommand = new DownloadFile(_fileService, commandOptions);
                    break;
                case AvailableCommands.FileInfo:
                    parsedCommand = new InfoFile(_fileService, commandOptions);
                    break;
                case AvailableCommands.FileMove:
                    parsedCommand = new MoveFile(_fileService, commandOptions);
                    break;
                case AvailableCommands.FileUpload:
                    parsedCommand = new UploadFile(_fileService, commandOptions);
                    break;
                case AvailableCommands.UserInfo:
                    parsedCommand = new InfoUser(_fileService);
                    break;
                default: throw new Exception("Non-existent command!");
            }

            return parsedCommand;
        }
    }
}
