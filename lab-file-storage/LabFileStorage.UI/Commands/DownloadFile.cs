using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class DownloadFile : ICommand
    {
        private readonly IFileService _fileService;
        private bool _isSucceeded;
        public List<string> Options { get; set; } = new List<string>();


        public DownloadFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool Execute()
        {
            string fileName = Options[0];
            string destinationPath = Options[1];
            _fileService.Download(fileName, destinationPath);
            _isSucceeded = true;
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? $"The file {Options[0]} has been downloaded" : "Error";
            return resultMessage;
        }
    }
}
