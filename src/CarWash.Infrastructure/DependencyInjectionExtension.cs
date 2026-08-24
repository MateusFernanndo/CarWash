using CarWash.Domain;
using CarWash.Domain.Repositories.CarService;
using CarWash.Infrastructure.DataAccess;
using CarWash.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWash.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);    
    }
    

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICarServiceWriteOnlyRepository, CarWashRepository>();
        services.AddScoped<ICarServiceUpdateOnlyRepository, CarWashRepository>();
        services.AddScoped<ICarServiceReadOnlyRepository, CarWashRepository>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<CarWashDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
