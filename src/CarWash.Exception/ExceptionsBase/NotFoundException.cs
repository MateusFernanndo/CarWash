using System.Net;

namespace CarWash.Exception.ExceptionsBase;

public class NotFoundException : CarWashException
{
    public NotFoundException(string message) : base(message) { } 
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
