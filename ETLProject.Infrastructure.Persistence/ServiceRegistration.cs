using ETLProject.Infrastructure.Persistence.DbContext;
using ETLProject.Infrastructure.Persistence.Extractors;
using ETLProject.Infrastructure.Persistence.Extractors.ApiExtractors;
using ETLProject.Infrastructure.Persistence.Extractors.CsvExtractors;
using ETLProject.Infrastructure.Persistence.Extractors.DbExtractors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETLProject.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<VentasDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("VentasDB")),
                ServiceLifetime.Transient);


            services.AddTransient<CustomerCsvExtractor>();
            services.AddTransient<ProductCsvExtractor>();
            services.AddTransient<OrderCsvExtractor>();

            services.AddTransient<CustomerDbExtractor>();
            services.AddTransient<OrderDbExtractor>();
            services.AddTransient<OrderDetailDbExtractor>();
            services.AddTransient<ProductDbExtractor>();


            services.AddHttpClient<ApiProductExtractor>();
        }
    }
}