using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab02
{
    internal class FileRepository
    {
        public void Upload(string path)
        {
            byte[] fileContent = null;
            if (File.Exists(path))
            {
                fileContent = File.ReadAllBytes(path);
            }
            foreach (var b in fileContent)
            {
                Console.WriteLine(b);
            }
            using (BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate)))
            {
                bw.Write(fileContent);
            }
        }

        void Update() { }
        void Delete() { }
        void Get() { }
        FileMetaInformation GetMetaInformation()
        {
            throw new NotImplementedException();
        }
    }
}
