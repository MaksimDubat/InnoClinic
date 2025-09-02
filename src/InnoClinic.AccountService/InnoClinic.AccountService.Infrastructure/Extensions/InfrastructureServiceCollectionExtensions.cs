using InnoClinic.AccountService.Domain.Repositories;
using InnoClinic.AccountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.AccountService.Infrastructure.Registrations;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("AccountDb");

        services.AddDbContext<AccountServiceDbContext>(options =>
           options.UseNpgsql(connectionString,
               b => b.MigrationsAssembly(typeof(AccountServiceDbContext).Assembly.GetName().Name)
           )
        );

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        return services;
    }
}
