using Lab02.FileManagment;

namespace Lab02.Commands
{
    internal class InfoUser : ConsoleCommand
    {

        public override bool Execute()
        {
            double storageUsed = (double) (GetStorageSize() / 1000000);
            string userName = ConfigLoader.GetConfiguration()["Login"];
            string creationDate = ConfigLoader.GetConfiguration()["Creation date"];
            ResultMessage = $"login: {userName}\n" +
                $"creation date: {creationDate}\n" +
                $"storage used: {storageUsed} MB";
            return true;
        }

        private long GetStorageSize()
        {
            MetaInformationStorage metainf = new MetaInformationStorage();
            long storageUsed = 0;
            foreach (var pair in metainf.Storage)
            {
                storageUsed += pair.Value.Size;
            }
            return storageUsed;
        }
    }
}
