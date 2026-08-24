using AutoMapper;
using CarWash.Communication.Request;
using CarWash.Communication.Response;
using CarWash.Domain;
using CarWash.Domain.Repositories.CarService;
using CarWash.Exception.ExceptionsBase;

namespace CarWash.Application.UseCase.CarService.Register;

public class RegisterCarServicesUseCase : IRegisterCarServicesUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarServiceWriteOnlyRepository _repository; 

    public RegisterCarServicesUseCase(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ICarServiceWriteOnlyRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisterCarServiceJson> Execute(RequestCarServiceJson request)
    {
        Validade(request);
        var entity = _mapper.Map<Domain.Entities.CarService>(request);
        await _repository.Add(entity);
        await _unitOfWork.Commit();
        return _mapper.Map<ResponseRegisterCarServiceJson>(entity);

    }

    private void Validade(RequestCarServiceJson request)
    {
        var validator = new CarServicesValidator();
        var result = validator.Validate(request);
        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(m => m.ErrorMessage).ToList(); //Linq error list
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
