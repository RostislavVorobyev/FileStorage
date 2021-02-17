using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Interfaces;
using System;
using System.IO;

namespace LabFileStorage.BLL.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMetaInformationRepository _metaInformationRepository;

        public FileService(IFileRepository fileRepository, IMetaInformationRepository metaInformationRepository)
        {
            _fileRepository = fileRepository;
            _metaInformationRepository = metaInformationRepository;
        }

        public void Upload(string pathToFile)
        {
            if (FileExceedsSizeLimit(pathToFile))
            {
                throw new ArgumentException("File is too big to be uploaded");
            }
            _fileRepository.Upload(pathToFile);
            _metaInformationRepository.Add(pathToFile);
        }

        private bool FileExceedsSizeLimit(string pathToFile)
        {
            long fileSizeRestriction = 10000;
            FileInfo file = new FileInfo(pathToFile);
            return file.Length > fileSizeRestriction;
        }

        public void Download(string file, string downloadPath)
        {
            _fileRepository.Download(file, downloadPath);
            _metaInformationRepository.IncrementDownloads(file);
        }

        public string GetInfo(string fileName)
        {
            var meta = _metaInformationRepository.Get(fileName);
            return $"name: {meta.FileName}\n" +
                $"extension: {meta.Extension.Substring(1)}\n" +
                $"creation date: {meta.CreationDate.ToString("yyyy-MM-dd")}\n" +
                "login: Vorobey";
        }

        public void Move(string sourceFile, string destinationFile)
        {
            _fileRepository.Move(sourceFile, destinationFile);
            _metaInformationRepository.RenameFile(sourceFile, destinationFile);
        }

        public void Delete(string fileName)
        {
            _fileRepository.Delete(fileName);
            _metaInformationRepository.Delete(fileName);
        }

        public long GetStorageSize()
        {
            return _metaInformationRepository.GetStorageSize();
        }
    }
}
