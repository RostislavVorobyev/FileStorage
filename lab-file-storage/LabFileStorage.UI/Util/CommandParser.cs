using System;
using System.Text.RegularExpressions;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Commands;

namespace LabFileStorage.UI.Util
{
    internal class CommandParser
    {
        private readonly IFileService _fileService;

        public CommandParser(IFileService fileService)
        {
            _fileService = fileService;
        }

        internal ICommand Parse(string userInput)
        {
            try
            {
                var inputAtguments = SplitInputArguments(userInput);
                return GetParsedCommand(inputAtguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private string[] SplitInputArguments(string userInput) {
            userInput = userInput.Trim();
            return Regex.Split(userInput, @"\s+");
        }

        private ICommand GetParsedCommand(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("Illegal input");
            }
            string commandName = (args[0] + args[1]).ToLower();
            ICommand parsedCommand;
            switch (commandName)
            {
                case "filedelete":
                    parsedCommand = new DeleteFile(_fileService);
                    break;
                case "filedownload":
                    parsedCommand = new DownloadFile(_fileService);
                    break;
                case "fileinfo":
                    parsedCommand = new InfoFile(_fileService);
                    break;
                case "userlogin":
                    parsedCommand = new LoginUser();
                    break;
                case "filemove":
                    parsedCommand = new MoveFile(_fileService);
                    break;
                case "fileupload":
                    parsedCommand = new UploadFile(_fileService);
                    break;
                case "userinfo":
                    parsedCommand = new InfoUser(_fileService);
                    break;
                default: throw new Exception("Non-existent command!");
            }
            for (int i = 2; i < args.Length; i++)
            {
                parsedCommand.Options.Add(args[i]);
            }
            return parsedCommand;
        }
    }
}
