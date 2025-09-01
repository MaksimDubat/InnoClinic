using InnoClinic.AccountService.Application.Interfaces;
using InnoClinic.AccountService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoClinic.AccountService.Infrastructure.Registrations

{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AccountDb");

            services.AddDbContext<AccountServiceDbContext>(options =>
               options.UseNpgsql(connectionString,
                   b => b.MigrationsAssembly(typeof(AccountServiceDbContext).Assembly.GetName().Name)
               )
            );

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            return services;
        }
    }
}
