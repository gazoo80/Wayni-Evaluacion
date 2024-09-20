using DemoWayni.Application.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace DemoWayni.Application.Extensions
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationUtilities(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));

            return services;
        }
    }
}
