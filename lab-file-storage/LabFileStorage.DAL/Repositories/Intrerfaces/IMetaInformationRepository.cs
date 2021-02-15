using Lab02FileStorageDAL.Entities;
using System.Collections.Generic;

namespace LabFileStorage.DAL.Repositories.Intrerfaces
{
    public interface IMetaInformationRepository
    {
        Dictionary<string, FileMetaInformation> Storage { get; }

        void Add(string pathToFile);
        FileMetaInformation CreateMetaInformation(string pathToFile);
        void Delete(string fileName);
        FileMetaInformation Get(string fileName);
        void IncrementDownloads(string fileName);
        void RenameFile(string fileName, string newName);
        public long GetStorageSize();
    }
}