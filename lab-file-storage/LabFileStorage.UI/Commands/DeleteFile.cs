using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class DeleteFile : ICommand
    {
        private IFileService _fileService;

        public List<string> Options { get; set; }
        public string ResultMessage { get; set; }

        public DeleteFile(IFileService fileService)
        {
            _fileService = fileService;
        }
        public bool Execute()
        {
            string fileName = Options[0];
            _fileService.Delete(fileName);
            ResultMessage = $"File {Options[0]} has been removed";
            return true;
        }

        public string GetResultMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
