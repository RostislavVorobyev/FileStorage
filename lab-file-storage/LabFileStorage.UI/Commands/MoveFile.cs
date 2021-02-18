using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class MoveFile : ICommand
    {
        private readonly IFileService _fileService;
        private bool _isSucceeded;
        public List<string> Options { get; } = new List<string>();

        public MoveFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public bool Execute()
        {
            _fileService.Move(Options[0], Options[1]);
            _isSucceeded = true;
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = $"The file {Options[0]} has been moved to {Options[1]}";
            return resultMessage;
        }
    }
}
