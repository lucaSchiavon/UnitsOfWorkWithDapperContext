using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        //todo:creare l'interfaccia factory
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        private readonly IConfiguration _configuration;

        public OrderService(IUnitOfWork unitOfWork, IUnitOfWorkFactory unitOfWorkFactory, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkFactory = unitOfWorkFactory;
            _configuration = configuration;
        }

        public async Task CreateOrderAsync(string customerName, string product)
        {
            
           int CustId= _unitOfWork.Customers.Execute("INSERT INTO Customers (Name) VALUES (@Name)", new { Name = customerName });

            //se interoompiamo la transazione con un errore avviene il rollback
            //throw new Exception();

            
            _unitOfWork.Orders.Execute("INSERT INTO Orders(Product,CustomerId) VALUES(@Product,@CustomerId)", new { Product = product, CustomerId= CustId });

            //se non effettuiamo il commit avviene il rollback implicito
           
            _unitOfWork.Commit();
        }

        public async Task CreateOrderAsync2(string customerName, string product)
        {
            //qui abbiamo due contesti separati
            //questo significa che se qualcosa fallisce nel primo contesto il primo fa il rollback ma il secondo
            //è indipendente dal primo

            // Usa la factory per creare un'istanza di UnitOfWork
            using (var unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                // Crea un nuovo cliente
               
                int CustId = unitOfWork.Customers.Execute("INSERT INTO Customers (Name) VALUES (@Name)", new { Name = customerName });

              
                // Crea un nuovo ordine

                unitOfWork.Orders.Execute("INSERT INTO Orders(Product,CustomerId) VALUES(@Product,@CustomerId)", new { Product = product, CustomerId = CustId });

                // Esegui il commit delle modifiche (in una transazione unica)
                unitOfWork.Commit();
            }

            using (var unitOfWork = _unitOfWorkFactory.Create(_configuration))
            {
                // Crea un nuovo cliente

                int CustId = unitOfWork.Customers.Execute("INSERT INTO Customers (Name) VALUES (@Name)", new { Name = customerName });

                // Crea un nuovo ordine

                unitOfWork.Orders.Execute("INSERT INTO Orders(Product,CustomerId) VALUES(@Product,@CustomerId)", new { Product = product, CustomerId = CustId });

                // Esegui il commit delle modifiche (in una transazione unica)
                unitOfWork.Commit();
            }
        }

    }
}
