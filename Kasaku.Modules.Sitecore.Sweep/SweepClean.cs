using HtmlAgilityPack;
using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using Sitecore.Pipelines;

namespace Kasaku.Sitecore.Modules.Sweep
{
    public static class SweepClean
    {
        public static string Run (string value)
        {
            var document = new HtmlDocument()
            {
                OptionOutputOriginalCase = true,
                OptionWriteEmptyNodes = true
            };

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
