using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BookCatalogue.Application.Services;

namespace BookCatalogue.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IBookCatelogueService,BookCatelogueService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IMesseageQueueService, MesseageQueueService>();
            return services;
        }
    }
}
