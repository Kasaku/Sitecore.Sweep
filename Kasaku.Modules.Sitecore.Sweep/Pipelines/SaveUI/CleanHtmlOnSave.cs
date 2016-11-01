using Kasaku.Sitecore.Modules.Sweep.Configuration;
using Kasaku.Sitecore.Modules.Sweep.Matchers;
using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.Save;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.SaveUI
{
    public class CleanHtmlOnSave
    {
        protected static IMatchStrategy _matcher;

        static CleanHtmlOnSave()
        {
            _matcher = (IMatchStrategy)Factory.CreateObject("/sitecore/sweep/matchStrategy", true);

            Assert.IsNotNull(_matcher, "Sitecore.Sweep requires a valid sitecore/sweep/matchStrategy type to be defined.");
        }

        public virtual void Process(SaveArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (!SweepConfig.CleanOnItemSave)
                return;

            foreach (var saveItem in args.Items)
            {
                Item contentItem = Client.ContentDatabase.Items[saveItem.ID, saveItem.Language, saveItem.Version];

                foreach (var saveField in saveItem.Fields)
                {
                    var field = new Field(saveField.ID, contentItem);

                    if (_matcher.IsMatch(contentItem, field))
                    {
                        saveField.Value = SweepClean.Run(saveField.Value);                        
                    }
                }
            }
        }
    }
}
