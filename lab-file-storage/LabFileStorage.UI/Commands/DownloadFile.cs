using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class DownloadFile : ICommand
    {
        IFileService _fileService;

        public DownloadFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; set; } = new List<string>();

        public string ResultMessage { get; set; }

        public bool Execute()
        {
            string fileName = Options[0];
            string destinationPath = Options[1];
            _fileService.Download(fileName, destinationPath);
            ResultMessage = $"The file {Options[0]} has been downloaded";
            return true;
        }
    }
}
