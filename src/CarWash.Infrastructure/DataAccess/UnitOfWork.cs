using CarWash.Domain;

namespace CarWash.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly CarWashDbContext _dbContext;
    public UnitOfWork(CarWashDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
