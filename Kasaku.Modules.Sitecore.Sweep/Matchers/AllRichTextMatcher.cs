using Kasaku.Sitecore.Modules.Sweep.Utils;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Kasaku.Sitecore.Modules.Sweep.Matchers
{
    public class AllRichTextMatcher : IMatchStrategy
    {
        public bool IsMatch(Item contentItem, Field field)
        {
            return field.IsRichTextField();
        }
    }
}