using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql;
using TradieApp.Infrastructure.Data;
using TradieApp.Domain.Locations;
using TradieApp.Domain.Categories;
using TradieApp.Application.Repository;
using TradieApp.Application.UnitOfWork;
using TradieApp.Infrastructure.Repositories;

namespace TradieApp.Infrastructure;

public static class RegisterService
{
    public static void ConfigureInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("MySqlConnection")!;
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            options.UseSnakeCaseNamingConvention();
        });

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}