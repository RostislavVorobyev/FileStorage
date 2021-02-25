using System.IO;
using LabFileStorage.DAL.Repositories.Interfaces;

namespace LabFileStorage.DAL.Repositories.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly string _storagePath;

        public FileRepository(string storage)
        {
            _storagePath = storage;
        }

        public void Upload(string pathToFile)
        {
            string fileName = Path.GetFileName(pathToFile);
            string uploadPath = $"{_storagePath}{fileName}";
            File.Copy(pathToFile, uploadPath);
        }

        public void Download(string file, string downloadPath)
        {
            string pathToStoredFile = BuildStoredFilePath(file);
            File.Copy(pathToStoredFile, $@"{downloadPath}\{file}");
        }

        public void Move(string sourceFile, string destinationFile)
        {
            string pathToStoredFile = BuildStoredFilePath(sourceFile);
            File.Move(pathToStoredFile, $"{_storagePath}{destinationFile}");
        }

        private string BuildStoredFilePath(string fileName)
        {
            return $@"{_storagePath}\{fileName}";
        }

        public void Delete(string fileName)
        {
            string pathToStoredFile = BuildStoredFilePath(fileName);
            File.Delete(pathToStoredFile);
        }

    }
}
