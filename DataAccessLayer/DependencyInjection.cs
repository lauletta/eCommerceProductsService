using DataAccessLayer.ApplicationDbContext;
using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IProdcutRepository, ProductsRepository>();
        services.AddDbContext<ProductDbContext>
            (options =>
            {
                options.UseMySQL(configuration.GetConnectionString("MySqlConnection")!);
            });
        return services;
    }
}
