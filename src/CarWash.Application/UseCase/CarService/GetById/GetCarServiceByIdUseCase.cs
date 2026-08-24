using AutoMapper;
using CarWash.Communication.Response;
using CarWash.Domain.Repositories.CarService;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;

namespace CarWash.Application.UseCase.CarService.GetById;

public class GetCarServiceByIdUseCase : IGetCarServiceByIdUseCase
{
    private readonly ICarServiceReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetCarServiceByIdUseCase(
        ICarServiceReadOnlyRepository repository,
        IMapper mapper
        )
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseCarServiceJson> Execute(long id)
    {
        var result = await _repository.GetById(id);
        if(result is null)
        {
            throw new NotFoundException(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND);
        }
        return _mapper.Map<ResponseCarServiceJson>(result);
    }
}
