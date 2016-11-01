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
            if (args.Document.DocumentNode.ChildNodes.Count == 1
                 && args.Document.DocumentNode.FirstChild.NodeType == HtmlNodeType.Text)
            {
                var newChild = HtmlNode.CreateNode("<p></p>");
                newChild.AppendChild(args.Document.DocumentNode.FirstChild);

                args.Document.DocumentNode.ReplaceChild(
                    newChild,
                    args.Document.DocumentNode.FirstChild);

            }
        }
    }
}
