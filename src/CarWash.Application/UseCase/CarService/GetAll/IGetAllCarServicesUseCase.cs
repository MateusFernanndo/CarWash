using CarWash.Communication.Response;

namespace CarWash.Application.UseCase.CarService.GetAll;

public interface IGetAllCarServicesUseCase
{
    Task<ResponseAllCarServicesJson> Execute();
}
