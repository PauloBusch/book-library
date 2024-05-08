using BookLibrary.Domain.Repositories;
using BookLibrary.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace BookLibrary.Infra
{
    public static class BookInfraModule
    {
        public static IServiceCollection AddBookInfraModule(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            var connectionString = configuration.GetConnectionString("dbConnection1");
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
