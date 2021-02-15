using System;
using System.IO;
using LabFileStorage.BLL.Services.Intrerfaces;
using LabFileStorage.DAL.Repositories.Implementations;
using LabFileStorage.DAL.Repositories.Intrerfaces;

namespace LabFileStorage.BLL.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMetaInformationRepository _metaInformationRepository;

        public FileService()
        {
            _fileRepository = new FileRepository();
            _metaInformationRepository = new MetaInformationRepository();
        }

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

        private bool FileExceedsSizeLimit (string pathToFile)
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
            return _metaInformationRepository.Get(fileName).ToString();
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
