using System.IO;

namespace Lab02
{
    internal class FileRepository
    {
        private readonly MetaInformationStorage _storage;
        private readonly string _storagePath;

        public FileRepository()
        {
            _storage = new MetaInformationStorage();
            _storagePath = ConfigLoader.GetConfiguration()["Storage path"];
        }

        public void Upload(string path)
        {
            string uploadPath = $"{_storagePath}{Path.GetFileName(path)}";
            File.Copy(path, uploadPath);
            _storage.Add(path);
        }

        public void Download(string fileName, string destinationPath)
        {
            FileMetaInformation metaInformation = _storage.Get(fileName);
            string downloadPath = $"{_storagePath}\\{fileName}";
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

        public string GetInfo(string fileName)
        {
            return _storage.Get(fileName).ToString();
        }
    }
}
