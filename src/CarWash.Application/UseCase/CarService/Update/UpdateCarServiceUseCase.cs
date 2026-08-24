using AutoMapper;
using CarWash.Communication.Request;
using CarWash.Domain;
using CarWash.Domain.Repositories.CarService;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;

namespace CarWash.Application.UseCase.CarService.Update;

public class UpdateCarServiceUseCase : IUpdateCarServiceUseCase
{
    private readonly ICarServiceUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCarServiceUseCase(
        ICarServiceUpdateOnlyRepository repository, 
        IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task Execute(long id, RequestCarServiceUpdateJson request)
    {
        Validate(request);
        var carService = await _repository.GetById(id);

        if(carService is null)
        {
            throw new NotFoundException(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND);
        }
        _mapper.Map(request, carService);
        _repository.Update(carService);
        await _unitOfWork.Commit();
    }

    public void Validate(RequestCarServiceUpdateJson request)
    {
        var validator = new CarServiceUpdateValidator();
        var result = validator.Validate(request);
        if(result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(f=>f.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
