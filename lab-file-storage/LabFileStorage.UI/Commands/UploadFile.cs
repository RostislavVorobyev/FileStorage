using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class UploadFile : ICommand
    {
        private IFileService _fileService;
        private bool _isSucceeded;

        public UploadFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; } = new List<string>();

        public bool Execute()
        {
            _fileService.Upload(Options[0]);
            _isSucceeded = true;
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? $"The file {Options[0]} has been uploaded" : "Error";
            throw new System.NotImplementedException();
        }
    }

}
