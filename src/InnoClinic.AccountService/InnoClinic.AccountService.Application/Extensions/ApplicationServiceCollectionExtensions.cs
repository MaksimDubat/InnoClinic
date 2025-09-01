using InnoClinic.AccountService.Infrastructure.Registrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.AccountService.Application.Registrations;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);

        return services;
    }
}
