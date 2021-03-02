using System.Collections.Generic;
using Lab02FileStorageDAL.Entities;

namespace LabFileStorage.DAL.Repositories.Interfaces
{
    public interface IMetaInformationRepository
    {
        void Add(FileMetaInformation fileMetadata);
        void Delete(string fileName);
        void Update(FileMetaInformation fileMetadata);
        FileMetaInformation Get(string fileName);
        List<FileMetaInformation> GetAllMetadata();
    }
}