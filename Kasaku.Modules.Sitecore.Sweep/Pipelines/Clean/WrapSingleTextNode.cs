using System.Linq;
using HtmlAgilityPack;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// If the HTML has only a single-text node, wrap it in a Paragraph element.
    /// </summary>
    public class WrapSingleTextNode : SweepCleanProcessor
    {
        public override void Process(CleanPipelineArgs args)
        {
            if (args.Document.DocumentNode.HasChildNodes
                 && args.Document.DocumentNode.ChildNodes.Any(node => node.NodeType == HtmlNodeType.Text))
            {
                var newChild = HtmlNode.CreateNode("<p></p>");
                newChild.AppendChildren(args.Document.DocumentNode.ChildNodes);

                args.Document.DocumentNode.RemoveAllChildren();
                args.Document.DocumentNode.AppendChild(newChild);
            }
        }
    }
}
