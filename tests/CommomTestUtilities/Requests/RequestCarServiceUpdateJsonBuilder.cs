using Bogus;
using CarWash.Communication.Enums.CarServiceType;
using CarWash.Communication.Enums.PaymentStatus;
using CarWash.Communication.Enums.PaymentType;
using CarWash.Communication.Request;

namespace CommomTestUtilities.Requests;

public class RequestCarServiceUpdateJsonBuilder
{
    public static RequestCarServiceUpdateJson Build()
    {
        return new Faker<RequestCarServiceUpdateJson>()
            .RuleFor(r => r.Client, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.ClientNumber, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.CarAndRegistrationPlate, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.CarServiceType, faker => faker.PickRandom<CarServiceType>())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.PaymentStatus, faker => faker.PickRandom<PaymentStatus>())
            .RuleFor(r => r.DateDelivered, faker => DateOnly.FromDateTime(faker.Date.Future()));
    }
}
