using HtmlAgilityPack;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// Removes any nested elements from header elements (h1, h2, etc), whilst preserving the text within.
    /// 
    /// Before: <h4><strong>Some header test</strong></h4>
    /// After: <h4>Some header test</h4>
    /// </summary>
    public class RemoveInnerElementsFromHeaders : SweepCleanProcessor
    {
        public override void Process(CleanPipelineArgs args)
        {
            var nodes = args.Document.DocumentNode.SelectNodes("//h1//*|//h2//*|//h3//*|//h4//*|//h5//*|//h6//*");

            if (nodes != null)
            {
                foreach (var item in nodes)
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
}
