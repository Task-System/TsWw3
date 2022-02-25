using TelegramUpdater.Hosting;
using TsWw3TelegramBot;
using TsWw3TelegramBot.UpdateHandlers.Messages;

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
    var botConfigs = ctx.Configuration.GetSection("BotConfigs").Get<BotConfigs>();

    if (botConfigs.BotToken is null)
        throw new Exception("BotToken cannot be null.");

    services.AddTelegramUpdater<PollingUpdateWriter>( // Use your own manual update writer!
        botConfigs.BotToken,
        default, // default options
        (builder) => builder
            .AddExceptionHandler<Exception>(
                (u, e) =>
                {
                    u.Logger.LogWarning(exception: e, message: "Error while handlig ...");
                    return Task.CompletedTask;
                }, inherit: true)

            .AddMessageHandler<StartHandler>(),
        typeof(PreUpdateProcessor));

    services.AddLocalization(options =>
    {
        options.ResourcesPath = "Resources";
    });
}
