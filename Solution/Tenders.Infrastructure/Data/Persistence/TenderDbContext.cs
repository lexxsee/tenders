using Microsoft.EntityFrameworkCore;
using Tenders.Core.Entities;
using Tenders.Infrastructure.Data.Configurations;

namespace Tenders.Infrastructure.Data.Persistence
{
    public class TenderDbContext : DbContext
    {
        public TenderDbContext()
        {
        
        }
        
        public TenderDbContext(DbContextOptions<TenderDbContext> options) :
            base(options)
        {
        
        }

        public virtual DbSet<CitizenDocument> CitizenDocuments { get; set; }

        public virtual DbSet<CitizenDocumentType> CitizenDocumentTypes { get; set; }

        public virtual DbSet<Citizen> Citizens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CitizenDocumentConfiguration());
            modelBuilder.ApplyConfiguration(new CitizenDocumentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CitizenConfiguration());
        }

    }
}