using CarWash.Application.UseCase.CarService.Register;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Tests.CarServices.Register;

public class RegisterCarServiceUseCaseTests
{
    [Fact]
    public async Task Success()
    {
        var request = RequestCarServiceJsonBuilder.Build();
        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Client.Should().Be(request.Client);
    }

    [Fact]
    public async Task Error_Client_Empty()
    {
        var request = RequestCarServiceJsonBuilder.Build();
        request.Client = string.Empty;
        var useCase = CreateUseCase();

        var act = async() => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CLIENT_NAME_REQUIRED));
    }

    [Fact]
    public async Task Error_Car_And_Registration_Plate_Empty()
    {
        var request = RequestCarServiceJsonBuilder.Build();
        request.CarAndRegistrationPlate = string.Empty;
        var useCase = CreateUseCase();

        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        result.Where(er => er.GetErrors().Count == 1 && er.GetErrors().Contains(ResourceErrorMessages.CAR_AND_REGISTRATION_PLATE_REQUIRED));
    }


    private RegisterCarServicesUseCase CreateUseCase()
    {
        var repository = CarServicesWriteOnlyRepositoryBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var mapper = MapperBuilder.Build();

        return new RegisterCarServicesUseCase(mapper, unitOfWork, repository);
    }
}
