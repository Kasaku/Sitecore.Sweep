using HtmlAgilityPack;
using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	public class CleanerTester<T> where T : SweepCleanProcessor, new()
	{
		public void AssertParsedHtml(string input, string expectedOutput)
		{
			AssertParsedHtml(new T(), input, expectedOutput);
		}

		public void AssertParsedHtml(T processor, string input, string expectedOutput)
		{
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(input);

			processor.Process(new CleanPipelineArgs() {Document = htmlDoc});

			Assert.AreEqual(expectedOutput, htmlDoc.DocumentNode.InnerHtml,
				"Html output from processor does not match expected output.");
		}
	}
}