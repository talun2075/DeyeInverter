using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModbusWrapper;
using ModbusWrapper.Config;

namespace Bootstrapper
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)

        {
            
            services.Configure<ModbusOptions>(config.GetSection(ModbusOptions.ConfigSection));
            services.Configure<LanguageOptions>(config.GetSection(LanguageOptions.ConfigSection));
            return services;

        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)

        {

            services.AddSingleton<IDeyeModbus, DeyeModbus>();
            return services;

        }

    }
}