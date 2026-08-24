namespace CarWash.Application.UseCase.CarService.Delete;

public interface IDeleteCarServiceUseCase
{
    public Task Execute(long id);
}
