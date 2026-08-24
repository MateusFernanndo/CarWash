using Bogus;
using CarWash.Domain.Entities;
using CarWash.Domain.Enums;

namespace CommomTestUtilities.Entities;

public class CarServiceBuilder
{
    public static List<CarService> Collection(uint count =2)
    {
        var List = new List<CarService>();
        if(count == 0)
            count = 1;

        return List;
    }
    public static CarService Build()
    {
        return new Faker<CarService>()
            .RuleFor(r => r.Client, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.ClientNumber, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.CarAndRegistrationPlate, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.CarServiceType, faker => faker.PickRandom<CarServiceType>())
            .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.PaymentStatus, faker => faker.PickRandom<PaymentStatus>())
            .RuleFor(r => r.Date, faker => DateOnly.FromDateTime(faker.Date.Past()))
            .RuleFor(r => r.DateDelivered, faker => DateOnly.FromDateTime(faker.Date.Future()));
    }
}
