using CarWash.Communication.Enums.CarServiceType;

namespace CarWash.Communication.Response;

public class ResponseShortCarServiceJson
{
    public long Id { get; set; }
    public string Client { get; set; } = string.Empty;
    public string CarAndRegistrationPlate { get; set; } = string.Empty;
    public CarServiceType CarServiceType { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
}
