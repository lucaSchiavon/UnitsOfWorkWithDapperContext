using Core.Data;
using Core.Repositories;
using UintsOfWorkTest.Entities;

namespace UintsOfWorkTest.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDapperContext context) : base(context) { }

        //esempio di metodo implementato....
        public Customer GetCustomerByEmail(string email)
        {
            string sql = "SELECT * FROM Customers WHERE Email = @Email";
            return QueryFirstOrDefault(sql, new { Email = email });
        }
    }
}
