using System;
using System.IO;
using LabFileStorage.DAL.Repositories.Intrerfaces;

namespace LabFileStorage.DAL.Repositories.Implementations
{
    public class FileRepository : IFileRepository
    {
        private readonly string _storagePath;

        public FileRepository()
        {
            _storagePath = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}Database\\";
        }

        public void Upload(string path)
        {
            string fileName = Path.GetFileName(path);
            string uploadPath = $"{_storagePath}{fileName}";
            File.Copy(path, uploadPath);
        }

        public void Download(string fileName, string destinationPath)
        {
            string pathToStoredFile = BuildStoredFilePath(fileName);
            File.Copy(pathToStoredFile, $"{destinationPath}\\{fileName}");
        }

        public void Move(string sourceFile, string destinationFile)
        {
            string pathToStoredFile = BuildStoredFilePath(sourceFile);
            File.Move(pathToStoredFile, $"{_storagePath}{destinationFile}");
        }

        private string BuildStoredFilePath(string filename)
        {
            return $"{_storagePath}\\{filename}";
        }

        public void Delete(string fileName)
        {
            string pathToStoredFile = BuildStoredFilePath(fileName);
            File.Delete(pathToStoredFile);
        }

    }
}
