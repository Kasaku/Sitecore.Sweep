using HtmlAgilityPack;
using Sitecore.Pipelines;

namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    public class CleanPipelineArgs : PipelineArgs
    {
        public HtmlDocument Document { get; set; }
    }
}
