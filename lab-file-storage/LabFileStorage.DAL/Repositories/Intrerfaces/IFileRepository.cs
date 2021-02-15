namespace LabFileStorage.DAL.Repositories.Intrerfaces
{
    public interface IFileRepository
    {
        void Upload(string pathToFile);

        void Download(string file, string downloadPath);

        void Move(string currentNameFile, string futureNameFile);

        void Delete(string fileName);

    }
}
