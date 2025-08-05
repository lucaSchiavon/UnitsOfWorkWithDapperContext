using UintsOfWorkTest.Entities;
using UintsOfWorkTest.Repositories.Base;
using UintsOfWorkTestWithDapper.Data;

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
