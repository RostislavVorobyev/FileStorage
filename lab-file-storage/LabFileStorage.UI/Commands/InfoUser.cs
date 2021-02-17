using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Util;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class InfoUser : ICommand
    {
        private IFileService _fileService;

        public InfoUser(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; } = new List<string>();

        public string ResultMessage { get; set; }

        public bool Execute()
        {
            double storageUsed = (double)(_fileService.GetStorageSize() / 1000000);
            string userName = ConfigLoader.GetConfiguration()["Login"];
            string creationDate = ConfigLoader.GetConfiguration()["Creation date"];
            ResultMessage = $"login: {userName}\n" +
                $"creation date: {creationDate}\n" +
                $"storage used: {storageUsed} MB";
            return true;
        }

    }
}
