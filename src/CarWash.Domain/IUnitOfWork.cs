namespace CarWash.Domain;

public interface IUnitOfWork
{
    Task Commit();
}
