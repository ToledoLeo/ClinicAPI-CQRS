using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClinicSystem.Application;
using ClinicSystem.Infrastructure;

namespace ClinicSystem.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureInfrastructure(configuration);

        return services;
    }

    public static IServiceCollection AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplication(configuration);

        return services;
    }
}
