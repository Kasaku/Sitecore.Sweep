using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    public class RemoveEmptyNodes : SweepCleanProcessor
    {
        public string IgnoredElements { get; set; }

        public override void Process(CleanPipelineArgs args)
        {
            var parsedIgnoredElements = !string.IsNullOrEmpty(IgnoredElements)
                ? IgnoredElements.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                : Enumerable.Empty<string>();

            ProcessNode(args.Document.DocumentNode, parsedIgnoredElements);
        }

        protected virtual void ProcessNode(HtmlNode containerNode, IEnumerable<string> parsedIgnoredElements)
        {
            if (!containerNode.HasChildNodes &&
                containerNode.Attributes.Count == 0 && 
                !parsedIgnoredElements.Contains(containerNode.Name) && 
                string.IsNullOrWhiteSpace(containerNode.InnerText))
            {
                containerNode.Remove();
            }
            else
            {
                for (int i = containerNode.ChildNodes.Count - 1; i >= 0; i--)
                {
                    ProcessNode(containerNode.ChildNodes[i], parsedIgnoredElements);
                }
            }
        }
    }
}
