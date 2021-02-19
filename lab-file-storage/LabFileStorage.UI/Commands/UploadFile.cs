using System.Collections.Generic;
using LabFileStorage.BLL.Services.Interfaces;

namespace LabFileStorage.UI.Commands
{
    internal class UploadFile : ICommand
    {
        private readonly IFileService _fileService;
        private readonly List<string> _options;

        public UploadFile(IFileService fileService, List<string> options)
        {
            _fileService = fileService;
            _options = options;
        }

        public string Execute()
        {
            _fileService.Upload(_options[0]);

            return $"The file {_options[0]} has been uploaded";
        }
    }

}
