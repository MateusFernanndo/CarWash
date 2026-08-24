using CarWash.Application.AutoMapper;
using CarWash.Application.UseCase.CarService.Delete;
using CarWash.Application.UseCase.CarService.GetAll;
using CarWash.Application.UseCase.CarService.GetById;
using CarWash.Application.UseCase.CarService.Register;
using CarWash.Application.UseCase.CarService.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CarWash.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services) 
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterCarServicesUseCase, RegisterCarServicesUseCase>();
        services.AddScoped<IUpdateCarServiceUseCase, UpdateCarServiceUseCase>();
        services.AddScoped<IGetCarServiceByIdUseCase, GetCarServiceByIdUseCase>();
        services.AddScoped<IGetAllCarServicesUseCase, GetAllCarServicesUseCase>();
        services.AddScoped<IDeleteCarServiceUseCase, DeleteCarServiceUseCase>();
    }
}
