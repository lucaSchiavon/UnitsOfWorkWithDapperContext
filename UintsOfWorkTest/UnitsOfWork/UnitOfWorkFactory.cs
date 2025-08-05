using UintsOfWorkTestWithDapper.Data;


namespace UintsOfWorkTest.UnitsOfWork
{
    //public class UnitOfWorkFactory:IUnitOfWorkFactory
    //{
    //    private readonly AppDbContext _context;

    //    // Costruttore che riceve l'istanza di AppDbContext
    //    public UnitOfWorkFactory(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // Metodo per creare una nuova istanza di UnitOfWork
    //    public IUnitOfWork Create()
    //    {
    //        // Restituisce una nuova istanza di UnitOfWork
    //        return new UnitOfWork(_context);
    //    }
    //}

    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDapperContextFactory _contextFactory;

        public UnitOfWorkFactory(IDapperContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IUnitOfWork Create(IConfiguration configuration)
        {
            var context = _contextFactory.CreateScope();
            return new UnitOfWork(context);
        }
    }
}
