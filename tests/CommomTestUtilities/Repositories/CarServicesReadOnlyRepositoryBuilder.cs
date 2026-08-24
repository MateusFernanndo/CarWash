using CarWash.Domain.Entities;
using CarWash.Domain.Repositories.CarService;
using Moq;

namespace CommomTestUtilities.Repositories;

public class CarServicesReadOnlyRepositoryBuilder
{
    private readonly Mock<ICarServiceReadOnlyRepository> _repository;

    public CarServicesReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<ICarServiceReadOnlyRepository>();
    }

    public CarServicesReadOnlyRepositoryBuilder GetAll( List<CarService> carServices)
    {
        _repository.Setup(repository => repository.GetAll()).ReturnsAsync(carServices);
        return this;
    }

    public CarServicesReadOnlyRepositoryBuilder GetById(CarService? carService)
    {
        if(carService is not null)
            _repository.Setup(repository => repository.GetById(carService.Id)).ReturnsAsync(carService);
        return this;
    }

    public ICarServiceReadOnlyRepository Build() => _repository.Object;

}
