using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class InfoFile : ICommand
    {
        private IFileService _fileService;

        public InfoFile(IFileService fileService) 
        {
            _fileService = fileService;
        }

        public List<string> Options { get; set; } = new List<string>();

        public string ResultMessage { get; set ; }

        public bool Execute()
        {
            string fileName = Options[0];
            ResultMessage = _fileService.GetInfo(fileName);
            return true;
        }

    }
}
