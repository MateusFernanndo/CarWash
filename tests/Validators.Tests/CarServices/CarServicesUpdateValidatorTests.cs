using CarWash.Application.UseCase;
using CarWash.Application.UseCase.CarService;
using CarWash.Communication.Enums.CarServiceType;
using CarWash.Communication.Enums.PaymentStatus;
using CarWash.Communication.Enums.PaymentType;
using CarWash.Exception;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.CarServices;

public class CarServicesUpdateValidatorTests
{
    [Fact] //try the sucess case
    public void Sucess()
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        var result = validator.Validate(request);
        result.IsValid.Should().BeTrue();

    }

    [Theory] //it will force the error on client
    [InlineData("")]
    [InlineData("              ")]
    [InlineData(null)]
    public void Error_Client_Empty(string client)
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.Client = client;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.CLIENT_NAME_REQUIRED));
    }

    [Theory] //it will force the error on client number
    [InlineData("")]
    [InlineData("              ")]
    [InlineData(null)]
    public void Error_Client_Number_Empty(string clientNumber)
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.ClientNumber = clientNumber;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.CLIENT_NUMBER_REQUIRED));
    }

    [Theory] //it will force the error on car and registration plate
    [InlineData("")]
    [InlineData("              ")]
    [InlineData(null)]
    public void Error_Car_And_Registration_Plate_Empty(string carAndRegistrationPlate)
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.CarAndRegistrationPlate = carAndRegistrationPlate;

        var result = validator.Validate(request);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.CAR_AND_REGISTRATION_PLATE_REQUIRED));
    }

    [Fact] //it will force the error on car service method
    public void Error_Car_Service_Type_Method()
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.CarServiceType = (CarServiceType)500;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.CAR_SERVICE_INVALID));
    }

    [Theory] //it will force the error on amount method
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    [InlineData(-520)]
    public void Error_Amount_Method(decimal amount)
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.Amount = amount;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }

    [Fact] //it will force the error on payment type method
    public void Error_Payment_Type()
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.PaymentType = (PaymentType)500;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
    }

    [Fact] //it will force the error on payment status method
    public void Error_Payment_Status()
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.PaymentStatus = (PaymentStatus)500;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_STATUS_INVALID));
    }

    [Fact] //it will force the error on delivered date.
    public void Error_Date_Delivered_Past()
    {
        var validator = new CarServiceUpdateValidator();
        var request = RequestCarServiceUpdateJsonBuilder.Build();
        request.DateDelivered = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(c => c.ErrorMessage.Equals(ResourceErrorMessages.DATE_DELIVERED_CANNOT_BE_IN_THE_PAST));
    }

}
