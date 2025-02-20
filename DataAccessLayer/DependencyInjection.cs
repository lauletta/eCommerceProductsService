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

        string connectionString = configuration.GetConnectionString("MySqlConnection")!;

        string connection = connectionString.Replace("$SQL_HOST", Environment.GetEnvironmentVariable("SQL_HOST"))
            .Replace("$PASSWORD", Environment.GetEnvironmentVariable("PASSWORD"));
        services.AddDbContext<ProductDbContext>
            (options =>
            {
                options.UseMySQL(connection);
            });
        return services;
    }
}
