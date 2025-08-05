

using UintsOfWorkTestWithDapper.Extensions;

namespace UintsOfWorkTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.SetupDI();
            //builder.Services.AddScoped<IContext>(provider =>
            //{
            //    var configuration = provider.GetRequiredService<IConfiguration>();
            //    var connectionString = configuration.GetConnectionString("DefaultConnection");

            //    var factory = new DapperContextFactory(connectionString);
            //    return factory.CreateScope(); // restituisce IContext (cioè DapperContext)
            //});

            ////todo: è necessario iniettarlo? viene usato direttamente
            //builder.Services.AddScoped<IDapperContextFactory>(provider =>
            //{
            //    var configuration = provider.GetRequiredService<IConfiguration>();
            //    var connectionString = configuration.GetConnectionString("DefaultConnection");
            //    return new DapperContextFactory(connectionString);
            //});

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IUnitOfWorkFactory,UnitOfWorkFactory>();
            //builder.Services.AddScoped<OrderService>();
           // builder.Services.AddScoped<Cust>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           
            app.MapControllers();

            app.Run();
        }
    }
}
