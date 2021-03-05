using System;
using System.IO;
using System.Reflection;
using System.Resources;
using Lab02FileStorageDAL.Entities;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Interfaces;

namespace LabFileStorage.BLL.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;
        private readonly IMetadataRepository _metadataRepository;
        private readonly string _storagePath;

        public FileService(IFileRepository fileRepository, IMetadataRepository metadataRepository, string storagePath)
        {
            _fileRepository = fileRepository;
            _metadataRepository = metadataRepository;
            _storagePath = storagePath;
        }

        public void Upload(string pathToFile)
        {
            if (FileExceedsSizeLimit(pathToFile))
            {
                throw new ArgumentException("File is too big to be uploaded");
            }
            _fileRepository.Upload(pathToFile);
            FileMetaInformation metaToAdd = BuildMetaInformation(pathToFile);
            _metadataRepository.Add(metaToAdd);
        }

        private FileMetaInformation BuildMetaInformation(string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);
            string uploadPath = $"{_storagePath}{file.Name}";

            return new FileMetaInformation(file.Name, uploadPath, file.Extension, file.Length, file.CreationTime);
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
            IncrementDownloads(file);
        }

        private void IncrementDownloads(string file)
        {
            FileMetaInformation metaToIncrement = _metadataRepository.Get(file);
            metaToIncrement.DownloadsCounter++;
            _metadataRepository.Update(metaToIncrement);
        }

        public string GetInfo(string fileName)
        {
            var meta = _metadataRepository.Get(fileName);
            ResourceManager resourceManager = new ResourceManager("LabFileStorage.BLL.Resources.Strings", Assembly.GetExecutingAssembly());
            string messageTemplate = resourceManager.GetString("FileInfoMessage");
            return String.Format(messageTemplate, meta.FileName, meta.Extension.Substring(1), meta.CreationDate.ToString("yyyy-MM-dd"));
        }
         
        public void Move(string sourceFile, string destinationFile)
        {
            _fileRepository.Move(sourceFile, destinationFile);
            RenameFile(sourceFile, destinationFile);
        }

        private void RenameFile(string sourceFile, string destinationFile)
        {
            FileMetaInformation filemeta = _metadataRepository.Get(sourceFile);
            filemeta.FileName = destinationFile;
            string oldPath = filemeta.PathToFile;
            filemeta.PathToFile = oldPath.Substring(oldPath.LastIndexOf("\\")) + destinationFile;
            _metadataRepository.Update(filemeta);
        }

        public void Delete(string fileName)
        {
            _fileRepository.Delete(fileName);
            _metadataRepository.Delete(fileName);
        }

        public long GetStorageSize()
        {
            long totalStorageSize = 0;
            foreach (var metadata in _metadataRepository.GetAllMetadata())
            {
                totalStorageSize += metadata.Size;
            }

            return totalStorageSize;
        }
    }
}
