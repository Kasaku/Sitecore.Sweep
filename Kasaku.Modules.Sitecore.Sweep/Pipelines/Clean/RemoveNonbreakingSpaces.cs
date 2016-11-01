namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    public class RemoveNonbreakingSpaces : SweepCleanProcessor
    {
        public override void Process(CleanPipelineArgs args)
        {
            args.Document.DocumentNode.InnerHtml = args.Document.DocumentNode.InnerHtml.Replace("&nbsp;", string.Empty);
        }
    }

}
