using Core.Data;


namespace UintsOfWorkTest.UnitsOfWork
{


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
