using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

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
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(metainfPath, FileMode.OpenOrCreate))
                {
                    storage = (Dictionary<string, FileMetaInformation>)bf.Deserialize(fs);
                }
            }
            catch (SerializationException)
            {
                RestoreMetadataStorage();
            }
            
            return new Dictionary<string, FileMetaInformation>();
        }

        private void RestoreMetadataStorage()
        {
            //todo
            storage = new Dictionary<string, FileMetaInformation>(); 
            //throw new NotImplementedException();
        }
    }
}
