using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class UploadFile : ICommand
    {
        private IFileService _fileService;

        public UploadFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; } = new List<string>();

        public string ResultMessage { get; set; }

        public bool Execute()
        {
            _fileService.Upload(Options[0]);
            ResultMessage = $"The file {Options[0]} has been uploaded";
            return true;
        }
    }

}
