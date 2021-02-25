using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Util;

namespace LabFileStorage.UI.Commands
{
    internal class InfoUser : ICommand
    {
        private readonly IFileService _fileService;

        public InfoUser(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string Execute()
        {
            double storageUsed = (double)(_fileService.GetStorageSize() / 1000000);
            string userName = ConfigProvider.GetLogin();
            string creationDate = ConfigProvider.GetCreationDate();

            return $"login: {userName}\n" +
                $"creation date: {creationDate}\n" +
                $"storage used: {storageUsed} MB";
        }
    }
}
