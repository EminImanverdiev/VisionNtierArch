using DataAccess.Repositories.Concrete.EFCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<VisionDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IProductRepository, EfProductRepository>();
                 return services;
        }
    }
}
