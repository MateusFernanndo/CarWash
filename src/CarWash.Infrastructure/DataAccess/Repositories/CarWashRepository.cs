using CarWash.Domain.Entities;
using CarWash.Domain.Repositories.CarService;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Infrastructure.DataAccess.Repositories;

internal class CarWashRepository : ICarServiceWriteOnlyRepository, ICarServiceUpdateOnlyRepository, ICarServiceReadOnlyRepository
{
    private readonly CarWashDbContext _dbContext;
    public CarWashRepository(CarWashDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(CarService carService)
    {
        await _dbContext.CarServices.AddAsync(carService);
    }

    async Task<CarService?> ICarServiceUpdateOnlyRepository.GetById(long id)
    {
        return await _dbContext.CarServices.FirstOrDefaultAsync(carService => carService.Id == id);
    }

    public void Update(CarService carService)
    {
        _dbContext.CarServices.Update(carService);
    }

    async Task<CarService?> ICarServiceReadOnlyRepository.GetById(long id)
    {
        return await _dbContext.CarServices.AsNoTracking().FirstOrDefaultAsync(carService => carService.Id == id);
    }

    public async Task<List<CarService>> GetAll()
    {
        return await _dbContext.CarServices.AsNoTracking().ToListAsync();
    }

    public async Task Delete(long id)
    {
        var result = await _dbContext.CarServices.FindAsync(id);
        
        _dbContext.CarServices.Remove(result!);
    }
}
