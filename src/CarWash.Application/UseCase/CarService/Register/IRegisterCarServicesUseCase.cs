using CarWash.Communication.Request;
using CarWash.Communication.Response;

namespace CarWash.Application.UseCase.CarService.Register;

public interface IRegisterCarServicesUseCase
{
    Task<ResponseRegisterCarServiceJson> Execute(RequestCarServiceJson request);
}
