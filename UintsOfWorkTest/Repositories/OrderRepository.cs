using Core.Data;
using Core.Repositories;
using UintsOfWorkTest.Entities;

namespace UintsOfWorkTest.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDapperContext context) : base(context) { }

        //esempio di metodo implementato....
        public IList<Order> GetOrdersByCustomerId(int customerId)
        {
            string sql = "SELECT * FROM Orders WHERE CustomerId = @CustomerId";
            return Query(sql, new { CustomerId = customerId });
        }

        public IList<Order> GetOrdersByCustomerName(string customerName)
        {
            string sql = @"
            SELECT o.* 
            FROM Orders o
            INNER JOIN Customers c ON o.CustomerId = c.Id
            WHERE c.Name = @CustomerName";

            return Query(sql, new { CustomerName = customerName });
        }

        public Task<IList<Order>> GetOrdersByCustomerNameAsync(string customerName)
        {
            string sql = @"
            SELECT o.* 
            FROM Orders o
            INNER JOIN Customers c ON o.CustomerId = c.Id
            WHERE c.Name = @CustomerName";

            return QueryAsync(new { CustomerName = customerName },sql);
        }

       
    }
}
