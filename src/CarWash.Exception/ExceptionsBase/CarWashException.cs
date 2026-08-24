namespace CarWash.Exception.ExceptionsBase;

public abstract class CarWashException : SystemException
{
    protected CarWashException(string message) : base(message){}
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
