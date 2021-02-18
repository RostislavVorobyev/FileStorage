using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class DeleteFile : ICommand
    {
        private readonly IFileService _fileService;

        public List<string> Options { get; set; } = new List<string>();
        private bool _isSucceeded;

        public DeleteFile(IFileService fileService)
        {
            _fileService = fileService;
            Options = new List<string>();
        }

        public bool Execute()
        {
            string fileName = Options[0];
            _fileService.Delete(fileName);
            _isSucceeded = true;
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? $"File {Options[0]} has been removed" : "Error";
            return resultMessage;
        }
    }
}
