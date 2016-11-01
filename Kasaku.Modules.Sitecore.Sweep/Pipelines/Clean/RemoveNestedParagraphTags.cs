using System.Collections.Generic;
using HtmlAgilityPack;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// Removes any P or DIV elements that are within another P element, preserving the other HTML around it.
    /// </summary>
    public class RemoveNestedParagraphTags : SweepCleanProcessor
    {
        public override void Process(CleanPipelineArgs args)
        {
            List<HtmlNode> nodesToProcess = new List<HtmlNode>();

            var nodes = args.Document.DocumentNode.SelectNodes("//p//p");

            if (nodes != null)
                nodesToProcess.AddRange(nodes);
            
            nodes = args.Document.DocumentNode.SelectNodes("//p//div");

            if (nodes != null)
                nodesToProcess.AddRange(nodes);

            foreach (var item in nodesToProcess)
            {
                var positionNode = item;

                foreach (HtmlNode node in item.ChildNodes)
                {
                    positionNode = item.ParentNode.InsertAfter(node, positionNode);
                }

                item.Remove();
            }
        }
    }
}
