using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class DeleteFile : ICommand
    {
        private readonly IFileService _fileService;
        private readonly List<string> _options;

        public DeleteFile(IFileService fileService, List<string> options)
        {
            _fileService = fileService;
            _options = options;
        }

        public string Execute()
        {
            string fileName = _options[0];
            _fileService.Delete(fileName);

            return $"File {_options[0]} has been removed";
        }
    }
}
