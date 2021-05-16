using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BookCatalogue.Application;
using BookCatalogue.Tests.Database;

namespace BookCatalogue.Tests
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTests(this IServiceCollection services, IConfiguration configuration)
        {
            var descriptor = new ServiceDescriptor(typeof(IApplicationDbContext), typeof(ApplicationInMemoryDbContext), ServiceLifetime.Scoped);
            services.Replace(descriptor);

            return services;
        }
    }
}
