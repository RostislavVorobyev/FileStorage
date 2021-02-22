using System;
using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util
{
    internal class FileCommandParser : CommandLineParser
    {
        private readonly IFileService _fileService;
        private const string fileDeleteCommand = "file delete";
        private const string fileDownloadCommand = "file download";
        private const string fileInfoCommand = "file info";
        private const string fileMoveCommand = "file move";
        private const string fileUploadCommand = "file upload";
        private const string userInfoCommand = "user info";

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
                case fileDeleteCommand:
                    parsedCommand = new DeleteFile(_fileService, commandOptions);
                    break;
                case fileDownloadCommand:
                    parsedCommand = new DownloadFile(_fileService, commandOptions);
                    break;
                case fileInfoCommand:
                    parsedCommand = new InfoFile(_fileService, commandOptions);
                    break;
                case fileMoveCommand:
                    parsedCommand = new MoveFile(_fileService, commandOptions);
                    break;
                case fileUploadCommand:
                    parsedCommand = new UploadFile(_fileService, commandOptions);
                    break;
                case userInfoCommand:
                    parsedCommand = new InfoUser(_fileService);
                    break;
                default: throw new Exception("Non-existent command!");
            }

            return parsedCommand;
        }
    }
}
