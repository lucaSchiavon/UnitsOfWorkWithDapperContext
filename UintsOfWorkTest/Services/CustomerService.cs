using System.Collections.Generic;
using System.Data;
using UintsOfWorkTest.Entities;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest.Services
{
    public class CustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCustomerAsync(string customerName)
        {

            int CustId = _unitOfWork.Customers.Execute("INSERT INTO Customers (Name) VALUES (@Name)", new { Name = customerName });


            _unitOfWork.Commit();
        }
        //un esempio di come chiamare tutti i metodi base definiti nella repository base
        public async Task RunExamplesDapperAsync()
        {
            string name = "Alice";

            // 1. INSERT (Execute)
            int rows = _unitOfWork.Customers.Execute("INSERT INTO Customers (Name) VALUES (@Name)", new { Name = name });
            _unitOfWork.Commit();
            // 2. SELECT LIST (Query)
            IList<Customer> customers = _unitOfWork.Customers.Query("SELECT * FROM Customers");

            // 3. SELECT ASYNC (QueryAsync)
            IList<Customer> customersAsync = await _unitOfWork.Customers.QueryAsync(
              null,
              sql: "SELECT * FROM Customers"
            );

            // 3b. SELECT ASYNC (QueryAsync)
            IReadOnlyList<dynamic> objectsAsync = await _unitOfWork.Customers.QueryDynamicAsync(
              "SELECT * FROM Customers",
              null
            );


            //metodi per scorrersi la lista di dynamic
            foreach (var row in objectsAsync)
            {
                //Attenzione: Se il campo non esiste o è null, otterrai una RuntimeBinderException
                Console.WriteLine($"Id: {row.Id}, Name: {row.Name}");
            }


            foreach (var row in objectsAsync)
            {
                var dict = (IDictionary<string, object>)row;
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }


            // 4. QueryFirstOrDefault
            Customer customer = _unitOfWork.Customers.QueryFirstOrDefault(
                "SELECT * FROM Customers WHERE Name = @Name",
                new { Name = name }
            );


            // 5. QueryFirstOrDefaultAsync
            Customer customerAsync = await _unitOfWork.Customers.QueryFirstOrDefaultAsync(
                "SELECT * FROM Customers WHERE Name = @Name",
                new { Name = name }
            );

            // 6. QuerySingleOrDefault
            Customer singleCustomer = _unitOfWork.Customers.QuerySingleOrDefault(
                "SELECT * FROM Customers WHERE Id = @Id",
                new { Id = 1 }
            );

            // 7. ExecuteScalar
            int count = _unitOfWork.Customers.ExecuteScalar<int>("SELECT COUNT(*) FROM Customers");

            // 8. ExecuteScalarAsync
            int asyncCount = await _unitOfWork.Customers.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Customers");

            // 9. ExecuteAsync
            int asyncInsert = await _unitOfWork.Customers.ExecuteAsync(
                "INSERT INTO Customers (Name) VALUES (@Name)",
                new { Name = "Bob" }
            );

            // 10. QueryMultiple
            var grid = _unitOfWork.Customers.QueryMultiple(
                "SELECT * FROM Customers; SELECT * FROM Orders;",
                commandType: CommandType.Text
            );

            var customerList = grid.Read<Customer>().ToList();
            var orderList = grid.Read<Order>().ToList(); // supponendo ci sia una classe Order

            // 11. QueryToDictionary
            Dictionary<int, string> customerMap = _unitOfWork.Customers.QueryToDictionary<int, string>(
                "SELECT Id, Name FROM Customers",
                row => (int)row.Id,
                row => (string)row.Name
            );

            // 12. QueryToDataTable
            DataTable table = _unitOfWork.Customers.QueryToDataTable("SELECT * FROM Customers");

            // 13. BulkInsert
            _unitOfWork.Customers.BulkInsert(new List<Customer>
            {
                new Customer { Name = "Bulk1" },
                new Customer { Name = "Bulk2" }
            }, "Customers");

            // 14. QueryWithMapping
            var mapped = _unitOfWork.Customers.QueryWithMapping<Customer, Order, (Customer, Order)>(
                sql: @"
                    SELECT c.*, o.*
                    FROM Customers c
                    INNER JOIN Orders o ON c.Id = o.CustomerId",
                map: (c, o) => (c, o),
                splitOn: "Id"
            );

            // 15. Commit
            _unitOfWork.Commit();
        }

        public async Task RunExamplesDapperSimpleCrud()
        {
            // Create new customer
            var newCustomer = new Customer
            {
                Name = "Charlie"
                // aggiungi altri campi se esistono
            };

            // 1. Insert (sync)
            int? newId = _unitOfWork.Customers.Insert(newCustomer);
            Console.WriteLine($"Inserted Customer ID (sync): {newId}");

            //_unitOfWork.Commit();

            // 2. Get (sync)
            Customer retrievedCustomer = _unitOfWork.Customers.Get(newId);
            Console.WriteLine($"Retrieved Customer: {retrievedCustomer?.Name}");

            // 3. GetList (sync)
            IEnumerable<Customer> customerList = _unitOfWork.Customers.GetList(new { Name = "Charlie" });
            foreach (var c in customerList)
                Console.WriteLine($"Listed Customer: {c.Name}");

            // 4. Update (sync)
            if (retrievedCustomer != null)
            {
                retrievedCustomer.Name = "Charlie Updated";
                int updated = _unitOfWork.Customers.Update(retrievedCustomer);
                Console.WriteLine($"Updated Rows: {updated}");
            }

            // 5. Delete by entity (sync)
            if (retrievedCustomer != null)
            {
                int deleted = _unitOfWork.Customers.Delete(retrievedCustomer);
                Console.WriteLine($"Deleted Rows (by entity): {deleted}");
            }

            // 6. Delete by id (sync)
            if (newId.HasValue)
            {
                int deletedById = _unitOfWork.Customers.Delete(newId.Value);
                Console.WriteLine($"Deleted Rows (by ID): {deletedById}");
            }

            // 7. DeleteList (sync)
            int deletedList = _unitOfWork.Customers.DeleteList(new { Name = "Charlie Updated" });
            Console.WriteLine($"Deleted Rows (by condition): {deletedList}");

            // 8. RecordCount (sync)
            int totalCount = _unitOfWork.Customers.RecordCount();
            Console.WriteLine($"Total Customer Count: {totalCount}");

            // ASYNC VARIANTI
            var asyncCustomer = new Customer { Name = "Async Joe" };

            // 9. InsertAsync
            int? asyncId = await _unitOfWork.Customers.InsertAsync(asyncCustomer);
            Console.WriteLine($"Inserted Customer ID (async): {asyncId}");

            // 10. GetAsync
            Customer asyncRetrieved = await _unitOfWork.Customers.GetAsync(asyncId);
            Console.WriteLine($"Retrieved Customer (async): {asyncRetrieved?.Name}");

            // 11. GetListAsync
            IEnumerable<Customer> asyncList = await _unitOfWork.Customers.GetListAsync(new { Name = "Async Joe" });
            foreach (var c in asyncList)
                Console.WriteLine($"Async Listed: {c.Name}");

            // 12. UpdateAsync
            if (asyncRetrieved != null)
            {
                asyncRetrieved.Name = "Async Joe Updated";
                int updatedAsync = await _unitOfWork.Customers.UpdateAsync(asyncRetrieved);
                Console.WriteLine($"Updated Rows (async): {updatedAsync}");
            }

            // 13. DeleteAsync by entity
            if (asyncRetrieved != null)
            {
                int deletedAsync = await _unitOfWork.Customers.DeleteAsync(asyncRetrieved);
                Console.WriteLine($"Deleted Rows (async by entity): {deletedAsync}");
            }

            // 14. DeleteAsync by id
            if (asyncId.HasValue)
            {
                int deletedByIdAsync = await _unitOfWork.Customers.DeleteAsync(asyncId.Value);
                Console.WriteLine($"Deleted Rows (async by ID): {deletedByIdAsync}");
            }

            // 15. DeleteListAsync
            int deletedListAsync = await _unitOfWork.Customers.DeleteListAsync(new { Name = "Async Joe Updated" });
            Console.WriteLine($"Deleted Rows (async by condition): {deletedListAsync}");

            // 16. RecordCountAsync
            int totalCountAsync = await _unitOfWork.Customers.RecordCountAsync();
            Console.WriteLine($"Total Customer Count (async): {totalCountAsync}");

            // Commit at
            _unitOfWork.Commit();

        }
    }

}
