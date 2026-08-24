using CarWash.Application.UseCase.CarService.GetById;
using CarWash.Domain.Entities;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Tests.CarServices.GetById;

public class GetCarServiceByIdUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var carService = CarServiceBuilder.Build();
        var useCase = CreateUseCase(carService);
        var result = await useCase.Execute(carService.Id);
        result.Should().NotBeNull();
        result.Id.Should().Be(carService.Id);
        result.Client.Should().Be(carService.Client);
        result.ClientNumber.Should().Be(carService.ClientNumber);
        result.CarAndRegistrationPlate.Should().Be(carService.CarAndRegistrationPlate);
        result.CarServiceType.Should().Be((CarWash.Communication.Enums.CarServiceType.CarServiceType)carService.CarServiceType);
        result.Amount.Should().Be(carService.Amount);
        result.PaymentStatus.Should().Be((CarWash.Communication.Enums.PaymentStatus.PaymentStatus)carService.PaymentStatus);
        result.PaymentType.Should().Be((CarWash.Communication.Enums.PaymentType.PaymentType)carService.PaymentType);
        result.Date.Should().Be(carService.Date);
        result.DateDelivered.Should().Be(carService.DateDelivered);

    }

    [Fact]
    public async Task Error_Car_Service_Not_Found()
    {
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(id: 10000);
        var result = await act.Should().ThrowAsync<NotFoundException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND));
    }

    public GetCarServiceByIdUseCase CreateUseCase (CarService? carService = null)
    {
        var repository = new CarServicesReadOnlyRepositoryBuilder().GetById(carService).Build();
        var mapper = MapperBuilder.Build();
        return new GetCarServiceByIdUseCase(repository, mapper);
    }
}
