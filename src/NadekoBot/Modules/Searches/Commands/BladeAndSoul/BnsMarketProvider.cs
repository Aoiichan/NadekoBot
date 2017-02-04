using Discord;
using Discord.API;
using NadekoBot.Extensions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NadekoBot.Modules.Searches.Commands.BladeAndSoul
{
    public static class BnsMarketProvider
    {
        private const string queryUrl = "http://www.bns.academy/enter/wp-content/themes/jupiter/market_sources/discordMarket.php?q={0}&region={1}&{2}=1";

        public static async Task<BnsItem> FindItem(string name, string region, string exact)
        {
            using (var http = new HttpClient())
            {
                var res = await http.GetStringAsync(String.Format(queryUrl, name.Trim().Replace(' ', '+'), region, exact)).ConfigureAwait(false);
                var item = JsonConvert.DeserializeObject<BnsItem>(res);
                if (item?.Name == null)
                    return null;
                item.Icon = await NadekoBot.Google.ShortenUrl(item.Icon);
                return item;
            }
        }
    }

    public class BnsItem
    {
        public bool Status { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Gold { get; set; }
        public string Silver { get; set; }
        public string Copper { get; set; }

        public EmbedBuilder GetEmbed() =>
            new EmbedBuilder().WithOkColor()
                              .WithImageUrl(Icon)
                              .WithTitle(Name)
                              .AddField(efb => efb.WithName("Gold").WithValue(Gold).WithIsInline(true))
                              .AddField(efb => efb.WithName("Silver").WithValue(Silver).WithIsInline(true))
                              .AddField(efb => efb.WithName("Copper").WithValue(Copper).WithIsInline(true))
                              .WithCurrentTimestamp()
                              .WithFooter(efb => efb.WithText("Service provided by BnS Academy"));

        public override string ToString() =>
$@"`Name:` {Name}
`Gold:` {Gold}
`Silver:` {Silver}
`Copper:` {Copper}
`Icon:` {Icon}";
    }
}
