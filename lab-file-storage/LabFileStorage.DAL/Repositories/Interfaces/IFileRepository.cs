namespace LabFileStorage.DAL.Repositories.Interfaces
{
    public interface IFileRepository
    {
        void Upload(string pathToFile);

        void Download(string file, string downloadPath);

        void Move(string sourceFile, string destinationFile);

        void Delete(string fileName);

    }
}
