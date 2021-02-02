using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab02
{
    internal class MetaInformationStorage
    {
        private Dictionary<string, FileMetaInformation> storage;
        private readonly string metainfPath;
        private readonly string storagePath;
        public MetaInformationStorage()
        {
            metainfPath = ConfigLoader.GetConfiguration()["Metainf Path"];
            storagePath = ConfigLoader.GetConfiguration()["Storage path"];
            storage = ReadData();
        }
        public Dictionary<string, FileMetaInformation> GetStorage()
        {
            return storage;
        }

        private Dictionary<string, FileMetaInformation> ReadData()
        {
            try
            {
                DeserializeMetainformationFile();
            }
            catch (SerializationException)
            {
                RestoreMetadataStorage();
            }
            return storage;
        }

        private void DeserializeMetainformationFile()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(metainfPath, FileMode.OpenOrCreate))
            {
                storage = (Dictionary<string, FileMetaInformation>)bf.Deserialize(fs);
            }
        }

        private void RestoreMetadataStorage()
        {
            string [] pathsToFiles = Directory.GetFiles(storagePath);
            storage = new Dictionary<string, FileMetaInformation>();
            foreach (var path in pathsToFiles)
            {
                FileMetaInformation metainf = GetFileMetaInformation(path);
                storage.Add(metainf.FileName, metainf);
            }
            SaveMetainformationStorage();
        }

        public FileMetaInformation GetFileMetaInformation(string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);
            return new FileMetaInformation(file.Name, pathToFile, file.Extension, file.Length, file.CreationTime);
        }

        public void SaveMetainformationStorage()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(metainfPath, FileMode.OpenOrCreate))
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
