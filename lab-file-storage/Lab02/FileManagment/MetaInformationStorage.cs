using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab02
{
    internal class MetaInformationStorage
    {
        private static Dictionary<string, FileMetaInformation> storage;
        private readonly string _metainfPath;
        private readonly string _storagePath;

        public MetaInformationStorage() 
        {
            _metainfPath = ConfigLoader.GetConfiguration()["Metainf Path"];
            _storagePath = ConfigLoader.GetConfiguration()["Storage path"];
            storage = ReadData();
        }
        
        private Dictionary<string, FileMetaInformation> ReadData()
        {
            try
            {
                DeserializeMetainformationStorage();
            }
            catch (SerializationException)
            {
                RestoreMetadataStorage();
            }
            return storage;
        }

        private void DeserializeMetainformationStorage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(_metainfPath, FileMode.OpenOrCreate))
            {
                storage = (Dictionary<string, FileMetaInformation>)bf.Deserialize(fs);
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

        public void Add(string pathToFile)
        {
            FileMetaInformation metainf = CreateMetaInformation(pathToFile);
            storage.Add(metainf.FileName, metainf);
            SaveMetainformationStorage();
        }

        public FileMetaInformation Get (string fileName)
        {
            return storage[fileName];
        }

        public void Delete (string fileName)
        {
            storage.Remove(fileName);
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
            storage[fileName].DownloadsCounter++;
            SaveMetainformationStorage();
        }

        public void RenameFile(string fileName, string newName)
        {
            FileMetaInformation meta = storage[fileName];
            meta.FileName = newName;
            meta.PathToFile = $"{_storagePath}{newName}";
            storage[newName] = meta;
            storage.Remove(fileName);
            SaveMetainformationStorage();
        }

        private void SaveMetainformationStorage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(_metainfPath, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, storage);
            }
        }

        public void PrintMetainf()
        {
            Console.WriteLine($"{storage.Count}");
            foreach (var m in storage)
            {
                Console.WriteLine(m.Value.ToString());
            }
        }
    }
}
