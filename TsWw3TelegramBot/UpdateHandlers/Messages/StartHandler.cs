using Microsoft.Extensions.Localization;
using System.Globalization;
using Telegram.Bot.Types;
using TelegramUpdater.FilterAttributes.Attributes;
using TelegramUpdater.Filters;
using TelegramUpdater.UpdateContainer;
using TelegramUpdater.UpdateHandlers.ScopedHandlers.ReadyToUse;

namespace TsWw3TelegramBot.UpdateHandlers.Messages
{
    [Command("start", '/', ArgumentsMode.NoArgs), Private]
    internal sealed class StartHandler : ScopedMessageHandler
    {
        private readonly IStringLocalizer<StartHandler> _localizer;
        private readonly ILogger<StartHandler> _logger;

        public StartHandler(
            IStringLocalizer<StartHandler> localizer,
            ILogger<StartHandler> logger)
        {
            _localizer = localizer;
            _logger = logger;
        }

        protected override async Task HandleAsync(IContainer<Message> cntr)
        {
            _logger.LogInformation("CurrentCulture is {CurrentCultureName}.", CultureInfo.CurrentUICulture.Name);
            await cntr.Response(_localizer["Message"]);
        }
    }
}
