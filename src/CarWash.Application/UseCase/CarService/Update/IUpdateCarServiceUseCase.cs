using CarWash.Communication.Request;

namespace CarWash.Application.UseCase.CarService.Update;

public interface IUpdateCarServiceUseCase
{
    public Task Execute(long id, RequestCarServiceUpdateJson request);
}
