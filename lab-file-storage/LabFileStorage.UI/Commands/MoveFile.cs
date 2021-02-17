using LabFileStorage.BLL.Services.Interfaces;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class MoveFile : ICommand
    {
        private IFileService _fileService;

        public MoveFile(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; } = new List<string>();

        public string ResultMessage { get; set; }

        public bool Execute()
        {
            _fileService.Move(Options[0], Options[1]);
            ResultMessage = $"The file {Options[0]} has been moved to {Options[1]}";
            return true;
        }
    }
}
