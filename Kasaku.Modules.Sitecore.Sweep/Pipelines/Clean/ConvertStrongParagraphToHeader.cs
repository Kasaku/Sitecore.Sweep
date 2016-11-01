namespace Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean
{
    /// <summary>
    /// Looks for paragraphs that are entirely strong / bold and replaces them with a header
    /// 
    /// Before: <p><strong>Some text</strong></p>
    /// After: <h4>Some text</h4>
    /// </summary>
    public class ConvertStrongParagraphToHeader : SweepCleanProcessor
    {
        public string ReplacementElement { get; set; }

        public override void Process(CleanPipelineArgs args)
        {
            var nodes = args.Document.DocumentNode.SelectNodes("//p");

            if (nodes != null)
            {
                foreach (var item in nodes)
                {
                    if (item.ChildNodes.Count == 1 && (item.FirstChild.Name == "strong" || item.FirstChild.Name == "b"))
                    {
                        item.RemoveChild(item.FirstChild, true);
                        item.Name = ReplacementElement ?? "h4";
                    }
                }
            }
        }
    }
}
