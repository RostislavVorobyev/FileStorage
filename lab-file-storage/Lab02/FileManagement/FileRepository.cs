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
            _storagePath = $"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"))}Database";
            _storageFileSizeRestriction = long.Parse(ConfigLoader.GetConfiguration()["Max file size"]);

        }

        public void Upload(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Length > _storageFileSizeRestriction)
            {
                throw new Exception("File is too big to be uploaded");
            }
            string uploadPath = $"{_storagePath}{file.Name}";
            File.Copy(path, uploadPath);
            _storage.Add(path);
        }

        public void Download(string fileName, string destinationPath)
        {
            FileMetaInformation metaInformation = _storage.Get(fileName);
            File.Copy(metaInformation.PathToFile, $"{destinationPath}\\{fileName}");
            _storage.IncrementDownloads(fileName);
        }

        public void Move(string sourceFile, string destinationFile)
        {
            string pathToFile = _storage.Get(sourceFile).PathToFile;
            _storage.RenameFile(sourceFile, destinationFile);
            File.Move(pathToFile, $"{_storagePath}{destinationFile}");
        }

        public void Delete(string fileName)
        {
            FileMetaInformation meta = _storage.Get(fileName);
            File.Delete(meta.PathToFile);
            _storage.Delete(fileName);
        }

        public FileMetaInformation GetInfo(string fileName)
        {
            return _storage.Get(fileName);
        }
    }
}
