namespace CarWash.Domain.Repositories.CarService;

public interface ICarServiceUpdateOnlyRepository
{
    Task<Entities.CarService?> GetById(long id);
    void Update(Entities.CarService carService);
}
