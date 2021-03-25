using System;
using System.Collections.Generic;
using System.Linq;
using Lab02FileStorageDAL.Entities;
using LabFileStorage.DAL.Context;
using LabFileStorage.DAL.Repositories.Interfaces;

namespace LabFileStorage.DAL.Repositories.Implementations
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly ApplicationDbContext _context;

        public MetadataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(FileMetaInformation fileMetadata)
        {
            _context.FileMetadata.Add(fileMetadata);
            _context.SaveChanges();
        }

        public FileMetaInformation Get(string fileName)
        {
            var metadata = _context.FileMetadata.Where(c => c.FileName == fileName).FirstOrDefault();
            if (metadata == null)
            {
                throw new ArgumentException($"File '{fileName}' not found.");
            }
            return metadata;
        }

        public List<FileMetaInformation> GetAllMetadata()
        {
            return _context.FileMetadata.ToList();
        }

        public void Delete(string fileName)
        {
            FileMetaInformation metadataToRemove = Get(fileName);
            _context.FileMetadata.Remove(metadataToRemove);
            _context.SaveChanges();
        }

        public void Update(FileMetaInformation fileMetadata)
        {
            _context.Update(fileMetadata);
            _context.SaveChanges();
        }
    }
}
