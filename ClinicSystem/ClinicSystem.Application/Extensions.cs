using ClinicSystem.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClinicSystem.Application;

public static class Extensions
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        services.ConfigureMediatR();

        return services;
    }

    private static IServiceCollection ConfigureMediatR(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
            cfg.AutoRegisterRequestProcessors = true;
            cfg.MediatorImplementationType = typeof(Mediator);
            cfg.Lifetime = ServiceLifetime.Transient;
            cfg.AddOpenBehavior(typeof(RequestTransactionBehavior<,>));
        });

        return services;
    }
}