using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class RemoveNestedParagraphTagsTests
	{
		[Test]
		public void SimpleNestedParagraph()
		{
			var tester = new CleanerTester<RemoveNestedParagraphTags>();

			tester.AssertParsedHtml("<p><p>nested paragraph</p></p>", "<p>nested paragraph</p>");
		}

		[Test]
		public void SimpleNestedDiv()
		{
			var tester = new CleanerTester<RemoveNestedParagraphTags>();

			tester.AssertParsedHtml("<p><div>nested paragraph</div></p>", "<p>nested paragraph</p>");
		}

		[Test]
		public void NestedParagraphWithOtherText()
		{
			var tester = new CleanerTester<RemoveNestedParagraphTags>();

			tester.AssertParsedHtml("<p><p>nested paragraph</p> and some regular text</p>", "<p>nested paragraph and some regular text</p>");
		}
	}
}