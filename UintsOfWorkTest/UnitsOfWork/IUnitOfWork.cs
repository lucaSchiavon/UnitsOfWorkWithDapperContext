using UintsOfWorkTest.Repositories;

namespace UintsOfWorkTest.UnitsOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }

        void Commit();
        //Task<int> CommitAsync();
    }
}
