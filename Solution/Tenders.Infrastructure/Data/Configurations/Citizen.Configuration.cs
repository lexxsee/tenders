using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenders.Core.Entities;

namespace Tenders.Infrastructure.Data.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.ToTable(@"Citizens", @"dbo");
            builder.Property(x => x.Id).HasColumnName(@"Id").HasColumnType(@"int").IsRequired().ValueGeneratedOnAdd()
                .HasPrecision(10, 0);
            builder.Property(x => x.SurName).HasColumnName(@"SurName").HasColumnType(@"nvarchar(100)").IsRequired()
                .ValueGeneratedNever().HasMaxLength(100);
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType(@"nvarchar(100)").IsRequired()
                .ValueGeneratedNever().HasMaxLength(100);
            builder.Property(x => x.Patronymic).HasColumnName(@"Patronymic").HasColumnType(@"nvarchar(100)")
                .ValueGeneratedNever().HasMaxLength(100);
            builder.Property(x => x.DateOfBirth).HasColumnName(@"DateOfBirth").HasColumnType(@"date").IsRequired()
                .ValueGeneratedNever();
            builder.Property(x => x.DateOfDeath).HasColumnName(@"DateOfDeath").HasColumnType(@"date")
                .ValueGeneratedNever();
            builder.HasKey(@"Id");
            builder.HasIndex(@"Id").IsUnique();
            builder.HasMany(x => x.CitizenDocuments).WithOne(op => op.Citizen).OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(@"CitizenId").IsRequired();
        }
    }
}