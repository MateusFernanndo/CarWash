using CarWash.Application.UseCase.CarService.GetAll;
using CarWash.Domain.Entities;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Tests.CarServices.GetAll;

public class GetAllCarServiceUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var carServices = CarServiceBuilder.Collection();
        var useCase = CreateUseCase(carServices);
        var result = await useCase.Execute();
        result.Should().NotBeNull();
    }

    private GetAllCarServicesUseCase CreateUseCase(List<CarService> carServices)
    {
        var repository = new CarServicesReadOnlyRepositoryBuilder().GetAll(carServices).Build();
        var mapper = MapperBuilder.Build();

        return new GetAllCarServicesUseCase(repository, mapper);
    }
}
