using AutoMapper;
using CarWash.Communication.Response;
using CarWash.Domain.Repositories.CarService;

namespace CarWash.Application.UseCase.CarService.GetAll;

public class GetAllCarServicesUseCase : IGetAllCarServicesUseCase
{
    private readonly ICarServiceReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCarServicesUseCase(
        ICarServiceReadOnlyRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
        
    }
    public async Task<ResponseAllCarServicesJson> Execute()
    {
        var result = await _repository.GetAll();
        return new ResponseAllCarServicesJson
        {
            CarServices = _mapper.Map<List<ResponseShortCarServiceJson>>(result)
        };
    }
}
