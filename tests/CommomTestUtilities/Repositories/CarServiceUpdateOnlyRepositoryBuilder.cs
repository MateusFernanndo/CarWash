using CarWash.Domain.Entities;
using CarWash.Domain.Repositories.CarService;
using Moq;

namespace CommomTestUtilities.Repositories;

public class CarServiceUpdateOnlyRepositoryBuilder
{
    private readonly Mock<ICarServiceUpdateOnlyRepository> _repository;

    public CarServiceUpdateOnlyRepositoryBuilder()
    {
        _repository = new Mock<ICarServiceUpdateOnlyRepository>();
    }

    public CarServiceUpdateOnlyRepositoryBuilder GetById(CarService? carService)
    {
        if(carService is not null)
            _repository.Setup(repository => repository.GetById(carService.Id)).ReturnsAsync(carService);
        return this;
    }

    public ICarServiceUpdateOnlyRepository Build() => _repository.Object;
}
