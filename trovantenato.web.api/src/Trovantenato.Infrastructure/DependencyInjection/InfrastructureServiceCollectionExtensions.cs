using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trovantenato.Domain.Interfaces.Repository;
using Trovantenato.Infrastructure.Context;
using Trovantenato.Infrastructure.Repository;

namespace Trovantenato.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("DbInMemory"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>

                options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("Trovantenato.Infrastructure")));

            }

            services.AddScoped<IImmigrantsRepository, ImmigrantsRepository>();
            services.AddScoped<IContactsRepository, ContactsRepository>();

            return services;
        }
    }
}
