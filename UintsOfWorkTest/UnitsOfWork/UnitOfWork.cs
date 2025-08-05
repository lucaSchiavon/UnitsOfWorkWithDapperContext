using UintsOfWorkTest.Repositories;
using UintsOfWorkTestWithDapper.Data;

namespace UintsOfWorkTest.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
 
        IDapperContext _dapperContext;
        public ICustomerRepository Customers { get; }
        public IOrderRepository Orders { get; }

        public UnitOfWork(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            Customers = new CustomerRepository(_dapperContext);
            Orders = new OrderRepository(_dapperContext);
        }

       
        public virtual void Commit()
        {
            _dapperContext.Commit();
        }

        public void Dispose()
        {
            _dapperContext.Dispose();
        }


     
    }
}
