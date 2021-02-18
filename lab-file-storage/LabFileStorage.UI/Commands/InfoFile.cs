using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class InfoFile : ICommand
    {
        private readonly IFileService _fileService;
        private bool _isSucceeded;
        private string _fileInfo;


        public InfoFile(IFileService fileService) 
        {
            _fileService = fileService;
        }

        public List<string> Options { get; set; } = new List<string>();


        public bool Execute()
        {
            string fileName = Options[0];
            _isSucceeded = true;
            _fileInfo = _fileService.GetInfo(fileName);
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? _fileInfo : "Error";
            return resultMessage;
        }
    }
}
