namespace LabFileStorage.BLL.Services.Intrerfaces
{
    public interface IFileService
    {
        void Upload(string pathToFile);

        void Download(string file, string downloadPath);

        void Move(string sourceFile, string destinationFile);

        void Delete(string fileName);

        string GetInfo(string fileName);

        long GetStorageSize();
    }
}
