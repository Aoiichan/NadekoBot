using Discord;
using NadekoBot.Attributes;
using NadekoBot.Extensions;
using NadekoBot.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NadekoBot.Modules.Searches.Commands.BladeAndSoul;
using NadekoBot.Modules.Searches.Commands.Models;
using Discord.Commands;


namespace NadekoBot.Modules.Searches
{
    public partial class Searches
    {
        [NadekoCommand, Usage, Description, Aliases]
        public async Task BnsMarket(string region, [Remainder] string query = null)
        {
            if (!(region == "eu" || region == "na"))
            {
                await Context.Channel.SendErrorAsync("Server unset.").ConfigureAwait(false);
                return;
            }

            if (!(await ValidateQuery(Context.Channel, query).ConfigureAwait(false))) return;
            await Context.Channel.TriggerTypingAsync().ConfigureAwait(false);

            var item = await BnsMarketProvider.FindItem(query, region, "exact");
            if (item == null)
            {
                item = await BnsMarketProvider.FindItem(query, region, "noexact");

                if (item == null)
                {
                    await Context.Channel.SendErrorAsync("Failed to find that item.").ConfigureAwait(false);
                    return;
                }
            }
            await Context.Channel.EmbedAsync(item.GetEmbed()).ConfigureAwait(false);
        }
    }
}