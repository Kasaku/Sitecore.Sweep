using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Kasaku.Sitecore.Modules.Sweep.Matchers
{
    public class ChainedMatcher : IMatchStrategy
    {
        public List<IMatchStrategy> Matchers { get; set; }

        public ChainedMatcher()
        {
            Matchers = new List<IMatchStrategy>();
        }

        public bool IsMatch(Item contentItem, Field field)
        {
            if (Matchers == null || !Matchers.Any())
            {
                return false;
            }

            return Matchers.Any(m => m.IsMatch(contentItem, field));
        }
    }
}