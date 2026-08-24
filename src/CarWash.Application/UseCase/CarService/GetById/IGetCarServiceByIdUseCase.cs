using CarWash.Communication.Response;

namespace CarWash.Application.UseCase.CarService.GetById;

public interface IGetCarServiceByIdUseCase
{
    public Task<ResponseCarServiceJson> Execute(long id);
}
