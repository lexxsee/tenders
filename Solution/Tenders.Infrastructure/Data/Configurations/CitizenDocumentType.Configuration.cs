using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenders.Core.Entities;

namespace Tenders.Infrastructure.Data.Configurations
{
    public class CitizenDocumentTypeConfiguration : IEntityTypeConfiguration<CitizenDocumentType>
    {

        public void Configure(EntityTypeBuilder<CitizenDocumentType> builder)
        {
            builder.ToTable(@"CitizenDocumentTypes", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedNever().HasPrecision(10, 0);
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType(@"nvarchar(50)").IsRequired().ValueGeneratedNever().HasMaxLength(50);
            builder.HasKey(@"Id");
            builder.HasIndex(@"Id").IsUnique();
            builder.HasMany(x => x.CitizenDocuments).WithOne(op => op.CitizenDocumentType).HasForeignKey(@"TypeId").IsRequired();
        }

    }

}
