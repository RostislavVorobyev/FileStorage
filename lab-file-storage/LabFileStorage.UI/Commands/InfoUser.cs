using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.UI.Util;
using LabFileStorage.UI.ViewModel;
using System.Collections.Generic;

namespace LabFileStorage.UI.Commands
{
    internal class InfoUser : ICommand
    {
        private readonly IFileService _fileService;
        private bool _isSucceeded;
        private UserViewModel userInfo;

        public InfoUser(IFileService fileService)
        {
            _fileService = fileService;
        }

        public List<string> Options { get; } = new List<string>();

        public bool Execute()
        {
            double storageUsed = (double)(_fileService.GetStorageSize() / 1000000);
            string userName = ConfigLoader.GetConfiguration()["Login"];
            string creationDate = ConfigLoader.GetConfiguration()["Creation date"];
            userInfo = new UserViewModel
            {
                UserName = userName,
                CreationDate = creationDate,
                StorageUsed = storageUsed
            };
            _isSucceeded = true;
            return _isSucceeded;
        }

        public string GetResultMessage()
        {
            string resultMessage = _isSucceeded ? $"login: {userInfo.UserName}\n" +
                $"creation date: {userInfo.CreationDate}\n" +
                $"storage used: {userInfo.StorageUsed} MB" : "Error";
            return resultMessage;
        }
    }
}
