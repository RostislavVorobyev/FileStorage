using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class MoveFile : ICommand
    {
        private readonly IFileService _fileService;
        private readonly List<string> _options;

        public MoveFile(IFileService fileService, List<string> options)
        {
            _fileService = fileService;
            _options = options;
        }

        public string Execute()
        {
            _fileService.Move(_options[0], _options[1]);

            return $"The file {_options[0]} has been moved to {_options[1]}";
        }
    }
}
