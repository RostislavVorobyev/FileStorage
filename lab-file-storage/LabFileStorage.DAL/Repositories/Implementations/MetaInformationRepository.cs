﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Lab02FileStorageDAL.Entities;
using LabFileStorage.DAL.Repositories.Interfaces;

namespace LabFileStorage.DAL.Repositories.Implementations
{
    public class MetaInformationRepository : IMetaInformationRepository
    {

        private Dictionary<string, FileMetaInformation> storage;
        private readonly string _metainfPath;
        private readonly string _storagePath;

        public Dictionary<string, FileMetaInformation> Storage
        {
            get
            {
                if (storage == null)
                {
                    storage = ReadMetadata();
                }
                return storage;
            }
        }

        public MetaInformationRepository()
        {
            _storagePath = $@"{AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("LabFileStorage.UI"))}Database\";
            _metainfPath = $@"{_storagePath}\Metainf.bin";
        }

        private Dictionary<string, FileMetaInformation> ReadMetadata()
        {
            try
            {
                return DeserializeMetainformationStorage();
            }
            catch (SerializationException)
            {
                RestoreMetadataStorage();
            }
            return storage;
        }

        private Dictionary<string, FileMetaInformation> DeserializeMetainformationStorage()
        {
            BinaryFormatter metainformationFormatter = new BinaryFormatter();
            using (FileStream metainformationFileStream = new FileStream(_metainfPath, FileMode.OpenOrCreate))
            {
                return (Dictionary<string, FileMetaInformation>)metainformationFormatter.Deserialize(metainformationFileStream);
            }
        }

        private void RestoreMetadataStorage()
        {
            string[] pathsToFiles = Directory.GetFiles(_storagePath);
            storage = new Dictionary<string, FileMetaInformation>();
            foreach (var path in pathsToFiles)
            {
                FileMetaInformation metainf = CreateMetaInformation(path);
                storage.Add(metainf.FileName, metainf);
            }
            SaveMetainformationStorage();
        }

        private void SaveMetainformationStorage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(_metainfPath, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, Storage);
            }
        }

        public void Add(string pathToFile)
        {
            FileMetaInformation metainf = CreateMetaInformation(pathToFile);
            Storage.Add(metainf.FileName, metainf);
            SaveMetainformationStorage();
        }

        public FileMetaInformation Get(string fileName)
        {
            return Storage[fileName];
        }

        public void Delete(string fileName)
        {
            Storage.Remove(fileName);
            SaveMetainformationStorage();
        }

        public FileMetaInformation CreateMetaInformation(string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);
            string uploadPath = $"{ _storagePath }{ file.Name}";
            return new FileMetaInformation(file.Name, uploadPath, file.Extension, file.Length, file.CreationTime);
        }

        public void IncrementDownloads(string fileName)
        {
            Storage[fileName].DownloadsCounter++;
            SaveMetainformationStorage();
        }

        public void RenameFile(string fileName, string newName)
        {
            FileMetaInformation meta = Storage[fileName];
            meta.FileName = newName;
            meta.PathToFile = $"{_storagePath}{newName}";
            Storage[newName] = meta;
            Storage.Remove(fileName);
            SaveMetainformationStorage();
        }

        public long GetStorageSize()
        {
            long storageUsed = 0;
            foreach (var pair in Storage)
            {
                storageUsed += pair.Value.Size;
            }
            return storageUsed;
        }
    }
}