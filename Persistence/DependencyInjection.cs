using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ToDoDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                
            });
            services.AddScoped((Func<IServiceProvider, IToDoDbContext>)(provider => provider.GetService<ToDoDbContext>()));
            

            return services;
        }
    }
}
