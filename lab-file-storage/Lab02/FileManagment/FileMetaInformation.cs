using System;

namespace Lab02
{
    [Serializable]
    public class FileMetaInformation
    {
        public string FileName { get; set; }
        public string PathToFile { get; set; }
        public string Extension { get; set; }
        public uint Size { get; set; }
        public DateTime CreationDate { get; set; }
        public uint DownloadsCounter { get; set; }

        public FileMetaInformation(string fileName, string pathToFile, string extension, uint size)
        {
            FileName = fileName;
            PathToFile = pathToFile;
            Extension = extension;
            Size = size;
            CreationDate = DateTime.Now;
            DownloadsCounter = 0;
        }
    }
}
