using System;
using System.IO;

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

        /*
         * file download <file-name> <destination-path> - скачивание файла c именем file-name из хранилища в директорию destination-path. 
         * Если файл уже существует, то выдавать сообщение об ошибке.
         */
        void Get(string fileName, string destinationPath) { }

        void Update() { }
        void Delete() { }
        
        FileMetaInformation GetMetaInformation()
        {
            throw new NotImplementedException();
        }
    }
}
