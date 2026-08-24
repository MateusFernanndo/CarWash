using CarWash.Communication.Enums.CarServiceType;
using CarWash.Communication.Enums.PaymentStatus;
using CarWash.Communication.Enums.PaymentType;

namespace CarWash.Communication.Request;

public class RequestCarServiceUpdateJson
{
    public string Client { get; set; } = string.Empty;
    public string ClientNumber { get; set; } = string.Empty;
    public string CarAndRegistrationPlate { get; set; } = string.Empty;
    public CarServiceType CarServiceType { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateOnly DateDelivered { get; set; }
}
