using System.Globalization;
using Telegram.Bot.Types;
using TelegramUpdater;
using TelegramUpdater.RainbowUtlities;

namespace TsWw3TelegramBot
{
    internal sealed class PreUpdateProcessor : AbstractPreUpdateProcessor
    {
        public PreUpdateProcessor(IUpdater updater) : base(updater)
        {
        }

        public override Task<bool> PreProcessor(ShiningInfo<long, Update> shiningInfo)
        {
            // Here we can set CurrentUICulture for every request.
            CultureInfo.CurrentUICulture = new CultureInfo("fa-IR", false);

            return Task.FromResult(true);
        }
    }
}
