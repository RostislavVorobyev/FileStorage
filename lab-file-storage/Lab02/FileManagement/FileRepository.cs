using System;
using System.IO;

namespace Lab02.FileManagment
{
    internal class FileRepository
    {
        private readonly MetaInformationStorage _storage;
        private readonly string _storagePath;
        private readonly long _storageFileSizeRestriction;

        public FileRepository()
        {
            _storage = new MetaInformationStorage();
            _storagePath = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}Database\\";
            _storageFileSizeRestriction = long.Parse(ConfigLoader.GetConfiguration()["Max file size"]);
        }

        public void Upload(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Length > _storageFileSizeRestriction)
            {
                throw new ArgumentException("File is too big to be uploaded");
            }
            string uploadPath = $"{_storagePath}{file.Name}";
            File.Copy(path, uploadPath);
            _storage.Add(path);
        }

        public void Download(string fileName, string destinationPath)
        {
            string pathToStoredFile = BuildStoredFilePath(fileName);
            File.Copy(pathToStoredFile, $"{destinationPath}\\{fileName}");
            _storage.IncrementDownloads(fileName);
        }

        public void Move(string sourceFile, string destinationFile)
        {
            string pathToStoredFile = BuildStoredFilePath(sourceFile);
            File.Move(pathToStoredFile, $"{_storagePath}{destinationFile}");
            _storage.RenameFile(sourceFile, destinationFile);
        }

        private string BuildStoredFilePath(string filename)
        {
            return $"{_storagePath}\\{filename}";
        }

        public void Delete(string fileName)
        {
            string pathToStoredFile = BuildStoredFilePath(fileName);
            File.Delete(pathToStoredFile);
            _storage.Delete(fileName);
        }

        public FileMetaInformation GetInfo(string fileName)
        {
            return _storage.Get(fileName);
        }
    }
}
