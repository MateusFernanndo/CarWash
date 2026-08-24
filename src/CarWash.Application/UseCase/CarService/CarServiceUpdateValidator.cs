using CarWash.Communication.Request;
using CarWash.Exception;
using FluentValidation;

namespace CarWash.Application.UseCase.CarService;

public class CarServiceUpdateValidator : AbstractValidator<RequestCarServiceUpdateJson>
{
    public CarServiceUpdateValidator()
    {
        RuleFor(service => service.Client).NotEmpty().WithMessage(ResourceErrorMessages.CLIENT_NAME_REQUIRED);
        RuleFor(service => service.ClientNumber).NotEmpty().WithMessage(ResourceErrorMessages.CLIENT_NUMBER_REQUIRED);
        RuleFor(service => service.CarAndRegistrationPlate).NotEmpty().WithMessage(ResourceErrorMessages.CAR_AND_REGISTRATION_PLATE_REQUIRED);
        RuleFor(service => service.CarServiceType).IsInEnum().WithMessage(ResourceErrorMessages.CAR_SERVICE_INVALID);
        RuleFor(service => service.Amount).GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(service => service.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
        RuleFor(service => service.PaymentStatus).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_STATUS_INVALID);
        RuleFor(service => service.DateDelivered).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage(ResourceErrorMessages.DATE_DELIVERED_CANNOT_BE_IN_THE_PAST);
    }
}
