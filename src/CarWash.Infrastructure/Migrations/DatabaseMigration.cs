using CarWash.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarWash.Infrastructure.Migrations;

public static class DatabaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<CarWashDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
