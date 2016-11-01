namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// Strips any inline styles added to elements
    /// </summary>
    public class StripInlineStyles : SweepCleanProcessor
    {
        public override void Process(CleanPipelineArgs args)
        {
            var nodesWithStyle = args.Document.DocumentNode.SelectNodes("//*[@style]");

            if (nodesWithStyle != null)
                foreach (var nodeWithStyle in nodesWithStyle)
                {
                    nodeWithStyle.Attributes.Remove("style");
                }
        }
    }
}
