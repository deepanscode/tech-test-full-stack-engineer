using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;

namespace TradieApp.Infrastructure.Data.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("jobs");
        builder.HasKey(j => j.Id);
        builder.Property(j => j.Status).HasConversion(
            v => v.ToString(),
            v => (JobStatusEnum)Enum.Parse(typeof(JobStatusEnum), v)).IsRequired().HasMaxLength(50);
        builder.Property(j => j.Price).IsRequired();
        builder.Property(j => j.Description).IsRequired();
        builder.Property(j => j.CreatedAt).IsRequired();
        builder.Property(j => j.UpdatedAt).IsRequired();
        
        builder.HasOne(j => j.Suburb)
            .WithMany()
            .HasForeignKey("SuburbId")
            .IsRequired();

        builder.HasOne(j => j.Category)
            .WithMany()
            .HasForeignKey("CategoryId")
            .IsRequired();

        // Configure the Contact value object
        builder.OwnsOne(j => j.Contact, contact =>
        {
            contact.Property(c => c.Name).IsRequired().HasMaxLength(255);
            contact.Property(c => c.Phone).IsRequired().HasMaxLength(255);
            contact.Property(c => c.Email).IsRequired().HasMaxLength(255);
        });
    }
}
