using CarWash.Application.UseCase.CarService.Delete;
using CarWash.Domain.Entities;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Tests.CarServices.Delete;

public class DeleteCarServiceUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var carService = CarServiceBuilder.Build();
        var useCase = CreateUseCase(carService);
        var act = async () => await useCase.Execute(carService.Id);
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Error_Car_Service_Not_Found()
    {
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(id: 10000);
        var result = await act.Should().ThrowAsync<NotFoundException>();
        result.Where( er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND));
    }

    private DeleteCarServiceUseCase CreateUseCase(CarService? carService = null)
    {
        var repository = CarServicesWriteOnlyRepositoryBuilder.Build();
        var repositoryReadOnly = new CarServicesReadOnlyRepositoryBuilder().GetById(carService).Build();
        var unitOfWork = UnitOfWorkBuilder.Build();

        return new DeleteCarServiceUseCase(repository, unitOfWork, repositoryReadOnly);
    }
}
