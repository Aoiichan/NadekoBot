using NadekoBot.Extensions;
using System.Collections.Generic;
using System.Net;

namespace NadekoBot.Modules.Searches.Models
{
    public class BnsItem
    {
        public bool Status { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Gold { get; set; }
        public string Silver { get; set; }
        public string Copper { get; set; }

        public override string ToString() =>
$@"`Name:` {WebUtility.HtmlDecode(Name)}
`Gold:` {Gold}
`Silver:` {Silver}
`Copper:` {Copper}
`Icon:` " + NadekoBot.Google.ShortenUrl(Icon).GetAwaiter().GetResult();
    }
}