using CarWash.Application.UseCase.CarService.Update;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Tests.CarServices.Update;

public class UpdateCarserviceUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        var carService = CarServiceBuilder.Build();
        var useCase = CreateUseCase(carService);
        var act = async () => await useCase.Execute(carService.Id, request);
        await act.Should().NotThrowAsync();

        carService.Client.Should().Be(request.Client);
        carService.ClientNumber.Should().Be(request.ClientNumber);
        carService.CarAndRegistrationPlate.Should().Be(request.CarAndRegistrationPlate);
        carService.CarServiceType.Should().Be((CarWash.Domain.Enums.CarServiceType)request.CarServiceType);
        carService.Amount.Should().Be(request.Amount);
        carService.PaymentStatus.Should().Be((CarWash.Domain.Enums.PaymentStatus)request.PaymentStatus);
        carService.PaymentType.Should().Be((CarWash.Domain.Enums.PaymentType)request.PaymentType);
        carService.DateDelivered.Should().Be(request.DateDelivered);
    }

    [Fact]
    public async Task Error_Client_Empty()
    {
        var carService = CarServiceBuilder.Build();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.Client = string.Empty;

        var useCase = CreateUseCase(carService);
        var act = async () => await useCase.Execute(carService.Id, request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CLIENT_NAME_REQUIRED));
    }

    [Fact]
    public async Task Error_Car_And_Registreation_Plate_Empty()
    {
        var carService = CarServiceBuilder.Build();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.CarAndRegistrationPlate = string.Empty;

        var useCase = CreateUseCase(carService);
        var act = async () => await useCase.Execute(carService.Id, request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CAR_AND_REGISTRATION_PLATE_REQUIRED));
    }

    [Fact]
    public async Task Error_Car_Service_Not_Found()
    {
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(id: 20000 , request);
        var result = await act.Should().ThrowAsync<NotFoundException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND));

    }

    private UpdateCarServiceUseCase CreateUseCase(CarWash.Domain.Entities.CarService? carService = null)
    {
        var repository = new CarServiceUpdateOnlyRepositoryBuilder().GetById(carService).Build();
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();

        return new UpdateCarServiceUseCase(repository, mapper, unitOfWork);
    }

}
