using BookLibrary.Domain.Interfaces.Repositories;
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
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            var connectionString = configuration.GetConnectionString("BookLibrary");
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
