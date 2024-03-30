using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectDash.Domain.Interfaces;

namespace ProjectDash.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ProjectDashDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IProjectDashDbContext>(provider =>
                provider.GetService<ProjectDashDbContext>());
            return services;
        }
    }
}
