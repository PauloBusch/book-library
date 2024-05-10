using BookLibrary.Infra;

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
            registerConsumers: configurator => { }
        );
    })
    .ConfigureLogging(logger =>
    {
        logger.AddConsole();
    });

var host = builder.Build();
await host.RunAsync();