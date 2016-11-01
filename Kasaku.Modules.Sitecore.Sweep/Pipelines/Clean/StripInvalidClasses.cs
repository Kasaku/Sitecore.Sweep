using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// Strips any unwanted classes from HTML elements. 
    /// 
    /// If ValidClasses are specified, this operates as a WHITELIST - only classes in this list will be left alone.
    /// If InvalidClasses are specific, this operates as a BLACKLIST - only classes in this list will be removed.
    /// 
    /// BLACKLIST mode takes preference: If both are specified, ValidClasses will be ignored.
    /// </summary>
    public class StripInvalidClasses : SweepCleanProcessor
    {
        protected readonly ArrayList _validClasses = new ArrayList();
        protected readonly ArrayList _invalidClasses = new ArrayList();

        public override void Process(CleanPipelineArgs args)
        {
            var nodesWithClasses = args.Document.DocumentNode.SelectNodes("//*[@class]");

            if (nodesWithClasses != null)
            {
                bool blacklistMode = _invalidClasses.Count > 0;

                foreach (var nodeWithClass in nodesWithClasses)
                {
                    List<string> classes = nodeWithClass.Attributes["class"].Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (blacklistMode)
                        classes.RemoveAll(x => _invalidClasses.Contains(x));
                    else
                        classes.RemoveAll(x => !_validClasses.Contains(x));

                    if (classes.Any())
                        nodeWithClass.Attributes["class"].Value = classes.Aggregate((a, b) => a + " " + b);
                    else
                        nodeWithClass.Attributes.Remove("class");
                }
            }
        }

        public ArrayList ValidClasses
        {
            get
            {
                return this._validClasses;
            }
        }

        public ArrayList InvalidClasses
        {
            get
            {
                return this._invalidClasses;
            }
        }

    }
}
