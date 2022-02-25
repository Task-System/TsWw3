using TelegramUpdater.Hosting;
using TsWw3TelegramBot;
using TsWw3TelegramBot.UpdateHandlers.Messages;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((ctx, services) =>
    {
        var botConfigs = ctx.Configuration.GetSection("BotConfigs").Get<BotConfigs>();

        services.AddTelegramUpdater<PollingUpdateWriter>(
            botConfigs.BotToken?? throw new Exception("BotToken cannot be null."),
            default, // default options
            (builder) => builder
                .AddExceptionHandler<Exception>(
                    (u, e) =>
                    {
                        u.Logger.LogWarning(exception: e, message: "Error while handlig ...");
                        return Task.CompletedTask;
                    }, inherit: true)

                // Add handlers here.
                .AddMessageHandler<StartHandler>(),

            typeof(PreUpdateProcessor));

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
    })
    .Build();

// Run the host
await host.RunAsync();
