using Danske.Homework.Application.Contracts.Logging;
using Danske.Homework.Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Danske.Homework.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}