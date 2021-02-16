using System;

namespace Lab02FileStorageDAL.Entities
{
    [Serializable]
    public class FileMetaInformation
    {
        public string FileName { get; set; }
        public string PathToFile { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime CreationDate { get; set; }
        public uint DownloadsCounter { get; set; }

        public FileMetaInformation(string fileName, string pathToFile, string extension, long size, DateTime creationDate)
        {
            FileName = fileName;
            PathToFile = pathToFile;
            Extension = extension;
            Size = size;
            CreationDate = creationDate;
            DownloadsCounter = 0;
        }

    }
}
