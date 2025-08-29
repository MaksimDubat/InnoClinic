using InnoClinic.AccountService.Domain.DataBase;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.AccountService.WebAPI.Registrations;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AccountServiceDbContext>(options =>
           options.UseNpgsql(connectionString,
               b => b.MigrationsAssembly(typeof(AccountServiceDbContext).Assembly.GetName().Name)
           )
        );

        return services;
    }
}
    