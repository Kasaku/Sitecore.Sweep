using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using Sitecore.Pipelines;
using Sitecore.WordOCX.HtmlDocument;

namespace Kasaku.Sitecore.Modules.Sweep
{
    public static class SweepClean
    {
        public static string Run (string value)
        {
            var document = new HtmlDocument();
            document.LoadHtml(value);

            var pipelineArgs = new CleanPipelineArgs()
            {
                Document = document
            };

            CorePipeline.Run("sweep.clean", pipelineArgs);

            return document.DocumentNode.OuterHtml;
        }
    }
}
