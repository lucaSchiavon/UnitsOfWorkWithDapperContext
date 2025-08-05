using Core.Data;
using UintsOfWorkTest.Services;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTestWithDapper.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void SetupDI(this IServiceCollection services)
        {
            services.AddScoped<IDapperContext>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                var factory = new DapperContextFactory(connectionString);
                return factory.CreateScope(); // restituisce IContext (cioè DapperContext)
            });

            //todo: è necessario iniettarlo? viene usato direttamente
            services.AddScoped<IDapperContextFactory>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                return new DapperContextFactory(connectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
            services.AddScoped<OrderService>();
            services.AddScoped<CustomerService>();
        }
    }
}
