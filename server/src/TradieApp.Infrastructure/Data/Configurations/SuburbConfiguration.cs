using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradieApp.Domain.Locations;

namespace TradieApp.Infrastructure.Configurations;

public class SuburbConfiguration : IEntityTypeConfiguration<Suburb>
{
    public void Configure(EntityTypeBuilder<Suburb> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(255);
        builder.Property(s => s.Postcode).IsRequired().HasMaxLength(4);
    }
}