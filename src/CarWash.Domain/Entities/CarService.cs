using CarWash.Domain.Enums;

namespace CarWash.Domain.Entities;

public class CarService
{
    public long Id { get; set; }
    public string Client { get; set; } = string.Empty;
    public string ClientNumber { get; set; } = string.Empty;
    public string CarAndRegistrationPlate { get; set; } = string.Empty;
    public CarServiceType CarServiceType { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateOnly Date { get; set; }
    public DateOnly DateDelivered { get; set; }
}
