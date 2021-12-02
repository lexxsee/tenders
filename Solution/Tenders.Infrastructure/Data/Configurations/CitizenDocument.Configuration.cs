using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenders.Core.Entities;

namespace Tenders.Infrastructure.Data.Configurations
{
    public class CitizenDocumentConfiguration : IEntityTypeConfiguration<CitizenDocument>
    {
        public void Configure(EntityTypeBuilder<CitizenDocument> builder)
        {
            builder.ToTable(@"CitizenDocuments", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd()
                .HasPrecision(10, 0);
            builder.Property(x => x.TypeId).HasColumnName(@"TypeId").HasColumnType(@"int").IsRequired()
                .ValueGeneratedNever().HasPrecision(10, 0);
            builder.Property(x => x.CitizenId).HasColumnName(@"CitizenId").HasColumnType(@"int").IsRequired()
                .ValueGeneratedNever().HasPrecision(10, 0);
            builder.Property(x => x.Number).HasColumnName(@"Number").HasColumnType(@"nvarchar(50)").IsRequired()
                .ValueGeneratedNever().HasMaxLength(50);
            builder.HasKey(@"Id");
            builder.HasIndex(@"Id").IsUnique();
            builder.HasOne(x => x.CitizenDocumentType).WithMany(op => op.CitizenDocuments).HasForeignKey(@"TypeId")
                .IsRequired();
            builder.HasOne(x => x.Citizen).WithMany(op => op.CitizenDocuments).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(@"CitizenId").IsRequired();
        }
    }
}