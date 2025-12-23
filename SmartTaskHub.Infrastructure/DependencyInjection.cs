using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartTaskHub.Application.Common.Interfaces;
using SmartTaskHub.Infrastructure.Persistence;

namespace SmartTaskHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            // Change the registration to this simpler version:
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<AppDbContext>());

            return services;
        }
    }
}
