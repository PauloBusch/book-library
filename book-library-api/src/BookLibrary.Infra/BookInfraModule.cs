using BookLibrary.Domain.Abstractions.Publishers;
using BookLibrary.Domain.Interfaces.Repositories;
using BookLibrary.Infra.Publishers;
using BookLibrary.Infra.Repositories;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace BookLibrary.Infra
{
    public static class BookInfraModule
    {
        public static IServiceCollection AddBookInfraModule(
            this IServiceCollection services, IConfiguration configuration,
            Action<IBusRegistrationConfigurator> registerConsumers
        )
        {
            services
                .AddDatabase(configuration)
                .AddMassTransit(configuration, registerConsumers);

            return services;       
        }

        private static IServiceCollection AddDatabase(
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

        private static IServiceCollection AddMassTransit(
            this IServiceCollection services, IConfiguration configuration,
            Action<IBusRegistrationConfigurator> registerConsumers
        )
        {
            var connectionString = configuration.GetConnectionString("ServiceBus");
            services.AddMassTransit(configurator =>
            {
                registerConsumers(configurator);
                configurator.UsingAzureServiceBus((context, cfg) =>
                {
                    cfg.Host(connectionString);
                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddScoped<IGenerateReportPublisher, GenerateReportPublisher>();

            return services;
        }
    }
}
