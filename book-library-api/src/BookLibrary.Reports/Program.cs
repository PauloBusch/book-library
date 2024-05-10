using BookLibrary.Domain.Abstractions.Services;
using BookLibrary.Infra;
using BookLibrary.Infra.Consumers;
using BookLibrary.Reports;

var configuration = null as IConfiguration;
var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((ctx, configBuilder) =>
    {
        configuration = configBuilder
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
        .Build();
    })
    .ConfigureServices(services =>
    {
        services.AddBookInfraModule(
            configuration,
            registerConsumers: configurator =>
            {
                configurator.AddConsumer<GenerateReportConsumer>();
            }
        );
        services.AddScoped<IReportService, ReportService>();
    })
    .ConfigureLogging(logger =>
    {
        logger.AddConsole();
    });

var host = builder.Build();
await host.RunAsync();