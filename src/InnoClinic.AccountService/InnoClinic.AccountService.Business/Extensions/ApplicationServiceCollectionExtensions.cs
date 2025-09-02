using InnoClinic.AccountService.Infrastructure.Registrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.AccountService.Business.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddAccountServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddRepositories();

        return services;
    }
}
