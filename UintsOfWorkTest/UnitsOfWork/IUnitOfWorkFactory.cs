using UintsOfWorkTest.Repositories;

namespace UintsOfWorkTest.UnitsOfWork
{
    public interface IUnitOfWorkFactory 
    {
        IUnitOfWork Create(IConfiguration configuration);
    }
}
