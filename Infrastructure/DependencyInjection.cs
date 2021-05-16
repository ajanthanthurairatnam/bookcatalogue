using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookCatalogue.Application;

namespace BookCatalogue.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("DefaultConnectionMemory"+ $"{Guid.NewGuid()}"));
               
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<IApplicationDbContext,ApplicationDbContext>();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<IApplicationDbContext>();


            return services;
        }
    }
}
