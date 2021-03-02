using Lab02FileStorageDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabFileStorage.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FileMetaInformation> FileMetadata { get; set; }

        //todo inject connection string from config
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Lab-05;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileMetaInformation>().HasKey(s => s.FileName);
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.PathToFile).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.Size).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.Extension).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.CreationDate).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.DownloadsCounter).IsRequired();
        }
    }
}
