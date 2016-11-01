using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace Kasaku.Sitecore.Modules.Sweep.Matchers
{
    public interface IMatchStrategy
    {
        bool IsMatch(Item contentItem, Field field);
    }
}
