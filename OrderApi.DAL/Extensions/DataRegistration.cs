using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderApi.DAL.Interfaces;
using OrderApi.DAL.Repositories;

namespace OrderApi.DAL.Extensions
{
    public static class DataRegistration
    {
        public static void ConfigureData(this IServiceCollection services)
        {
            var connectionString = GetConnectionString();
            services.AddDbContext<OrderApiContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPostTerminalRepository, PostTerminalRepository>();
        }

        private static string GetConnectionString()
        {
            //todo: move connection string parameters to some secret manager
            return "Host=localhost;Port=5433;Database=Test;Username=postgres;Password=postgres";
        }
    }
}
