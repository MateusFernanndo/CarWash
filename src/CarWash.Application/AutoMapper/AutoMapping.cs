using AutoMapper;
using CarWash.Communication.Request;
using CarWash.Communication.Response;
using CarWash.Domain.Entities;

namespace CarWash.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    public void RequestToEntity()
    {
        CreateMap<RequestCarServiceJson, CarService>();
        CreateMap<RequestCarServiceUpdateJson, CarService>();
    }
    public void EntityToResponse()
    {
        CreateMap<CarService, ResponseRegisterCarServiceJson>();
        CreateMap<CarService, ResponseCarServiceJson>();
        CreateMap<CarService, ResponseAllCarServicesJson>();
        CreateMap<CarService, ResponseShortCarServiceJson>();
    }
}
