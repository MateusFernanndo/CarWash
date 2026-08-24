using CarWash.Domain.Repositories.CarService;
using Moq;

namespace CommomTestUtilities.Repositories;

public class CarServicesWriteOnlyRepositoryBuilder
{
    public static ICarServiceWriteOnlyRepository Build()
    {
        var mock = new Mock<ICarServiceWriteOnlyRepository>();
        return mock.Object;
    }
}
