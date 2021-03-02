using System;
using System.IO;
using Lab02FileStorageDAL.Entities;
using LabFileStorage.BLL.Services.Interfaces;
using LabFileStorage.DAL.Repositories.Interfaces;

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
            FileMetaInformation metaToAdd = BuildMetaInformation(pathToFile);
            _metaInformationRepository.Add(metaToAdd);
        }

        private FileMetaInformation BuildMetaInformation (string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);
            //todo change path
            string uploadPath = $"{file.Name}";
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
            FileMetaInformation metaToIncrement = _metaInformationRepository.Get(file);
            metaToIncrement.DownloadsCounter++;
            _metaInformationRepository.Update(metaToIncrement);
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
            RenameFile(sourceFile, destinationFile);
        }

        private void RenameFile(string sourceFile, string destinationFile)
        {
            FileMetaInformation filemeta = _metaInformationRepository.Get(sourceFile);
            filemeta.FileName = destinationFile;
            string oldPath = filemeta.PathToFile;
            filemeta.PathToFile = oldPath.Substring(oldPath.LastIndexOf("\\")) + destinationFile;
            _metaInformationRepository.Update(filemeta);
        }

        public void Delete(string fileName)
        {
            _fileRepository.Delete(fileName);
            _metaInformationRepository.Delete(fileName);
        }

        public long GetStorageSize()
        {
            //todo implemet 
            return 150;
        }

    }
}
