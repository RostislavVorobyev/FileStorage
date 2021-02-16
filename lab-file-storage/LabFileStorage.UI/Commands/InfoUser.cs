using LabFileStorage.UI.Util;

namespace LabFileStorage.UI.Commands
{
    internal class InfoUser : ConsoleCommand
    {
        public override bool Execute()
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
