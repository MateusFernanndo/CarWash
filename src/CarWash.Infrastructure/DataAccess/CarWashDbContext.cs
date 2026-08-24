using CarWash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Infrastructure.DataAccess;

public class CarWashDbContext : DbContext
{
    public CarWashDbContext(DbContextOptions options) : base(options) { }
    public DbSet<CarService> CarServices { get; set; }
}

