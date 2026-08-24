namespace CarWash.Domain.Repositories.CarService;

public interface ICarServiceReadOnlyRepository
{
    Task<Entities.CarService?> GetById(long id);
    Task<List<Entities.CarService>> GetAll();
}
