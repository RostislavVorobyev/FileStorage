using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class InfoFile : ICommand
    {
        private readonly IFileService _fileService;
        private readonly List<string> _options;

        public InfoFile(IFileService fileService, List<string> options)
        {
            _fileService = fileService;
            _options = options;
        }

        public string Execute()
        {
            string fileName = _options[0];

            return _fileService.GetInfo(fileName);
        }
    }
}
