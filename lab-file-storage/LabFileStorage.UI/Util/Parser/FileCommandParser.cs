using System;
using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util.Parser
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
            string commandName = $"{inputArguments[0]} {inputArguments[1]}".ToLower();
            List<string> commandOptions = ParseCommandOptions(inputArguments);
            ICommand parsedCommand;
            switch (commandName)
            {
                case SupportedCommandConstants.FileDeleteCommand:
                    parsedCommand = new DeleteFile(_fileService, commandOptions);
                    break;
                case SupportedCommandConstants.FileDownloadCommand:
                    parsedCommand = new DownloadFile(_fileService, commandOptions);
                    break;
                case SupportedCommandConstants.FileInfoCommand:
                    parsedCommand = new InfoFile(_fileService, commandOptions);
                    break;
                case SupportedCommandConstants.FileMoveCommand:
                    parsedCommand = new MoveFile(_fileService, commandOptions);
                    break;
                case SupportedCommandConstants.FileUploadCommand:
                    parsedCommand = new UploadFile(_fileService, commandOptions);
                    break;
                case SupportedCommandConstants.UserInfoCommand:
                    parsedCommand = new InfoUser(_fileService);
                    break;
                default: throw new Exception("Non-existent command!");
            }

            return parsedCommand;
        }
    }
}
