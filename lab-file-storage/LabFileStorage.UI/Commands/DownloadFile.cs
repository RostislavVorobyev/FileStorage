using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class DownloadFile : ICommand
    {
        private readonly IFileService _fileService;
        private readonly List<string> _options;

        public DownloadFile(IFileService fileService, List<string> options)
        {
            _fileService = fileService;
            _options = options;
        }

        public string Execute()
        {
            string fileName = _options[0];
            string destinationPath = _options[1];
            _fileService.Download(fileName, destinationPath);

            return $"The file {_options[0]} has been downloaded";
        }
    }
}
