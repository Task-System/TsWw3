using System.Globalization;
using Telegram.Bot.Types;
using TelegramUpdater;
using TelegramUpdater.Hosting;
using TelegramUpdater.RainbowUtlities;
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
        PreProcess);

    services.AddLocalization(options=>
    {
        options.ResourcesPath = "Resources";
    });
}

/// <summary>
/// A fumction to call before processing any update.
/// </summary>
static Task<bool> PreProcess(IUpdater updater, ShiningInfo<long, Update> shiningInfo)
{
    // Here we can set CurrentUICulture for every request.
    CultureInfo.CurrentUICulture = new CultureInfo("fa-IR", false);

    return Task.FromResult(true);
}