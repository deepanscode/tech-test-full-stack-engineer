using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TradieApp.Domain.Categories;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Locations;
using TradieApp.Infrastructure.Configurations;
using TradieApp.Infrastructure.Data.Configurations;

namespace TradieApp.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<Suburb> Suburbs => Set<Suburb>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SuburbConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new JobConfiguration());
    }
}