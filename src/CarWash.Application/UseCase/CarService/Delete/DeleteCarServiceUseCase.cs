using CarWash.Domain;
using CarWash.Domain.Repositories.CarService;
using CarWash.Exception;
using CarWash.Exception.ExceptionsBase;

namespace CarWash.Application.UseCase.CarService.Delete;

public class DeleteCarServiceUseCase : IDeleteCarServiceUseCase
{
    private readonly ICarServiceReadOnlyRepository _carServicesReadOnly;
    private readonly ICarServiceWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarServiceUseCase(
        ICarServiceWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        ICarServiceReadOnlyRepository carServicesReadOnly)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _carServicesReadOnly = carServicesReadOnly;
    }
    public async Task Execute(long id)
    {
        var carService = await _carServicesReadOnly.GetById(id);

        if(carService is null)
        {
            throw new NotFoundException(ResourceErrorMessages.CAR_SERVICE_NOT_FOUND);
        }
        
        await _repository.Delete(id);
        await _unitOfWork.Commit();
    }
}
