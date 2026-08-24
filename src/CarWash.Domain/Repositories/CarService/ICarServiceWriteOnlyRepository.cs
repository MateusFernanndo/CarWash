namespace CarWash.Domain.Repositories.CarService;

public interface ICarServiceWriteOnlyRepository
{
    Task Add(Entities.CarService carService);
    Task Delete(long id);
}
