using TsWw3TelegramBot;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices(ServiceConfigurations);

// Build the host.
var host = builder.Build();

// Run the host
await host.RunAsync();

/// <summary>
/// A function to configure services for the host.
/// </summary>
static void ServiceConfigurations(HostBuilderContext ctx, IServiceCollection services)
{
    services.AddHostedService<Worker>();
}