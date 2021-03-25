using Lab02FileStorageDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LabFileStorage.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<FileMetaInformation> FileMetadata { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //sample data seeding to copmlete task 3
            modelBuilder.Entity<FileMetaInformation>()
                .HasData(new FileMetaInformation("filename", "samplepath", ".ext", 0, System.DateTime.Now) { Id = 1 });

            modelBuilder.Entity<FileMetaInformation>().HasKey(s => s.Id);
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.FileName).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.PathToFile).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.Size).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.Extension).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.CreationDate).IsRequired();
            modelBuilder.Entity<FileMetaInformation>().Property(s => s.DownloadsCounter).IsRequired();
        }
    }
}
