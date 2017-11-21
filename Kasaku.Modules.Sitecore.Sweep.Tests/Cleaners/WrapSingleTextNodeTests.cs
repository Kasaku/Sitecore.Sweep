using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class WrapSingleTextNodeTests
	{
		[Test]
		public void SimpleText()
		{
			var tester = new CleanerTester<WrapSingleTextNode>();

			tester.AssertParsedHtml("This is the content", "<p>This is the content</p>");
		}

		[Test]
		public void TextWithInnerElements()
		{
			var tester = new CleanerTester<WrapSingleTextNode>();

			tester.AssertParsedHtml("<strong>This</strong> is the content", "<p><strong>This</strong> is the content</p>");
			tester.AssertParsedHtml("This <strong>is the</strong> content", "<p>This <strong>is the</strong> content</p>");
			tester.AssertParsedHtml("This is the <strong>content</strong>", "<p>This is the <strong>content</strong></p>");
		}
	}
}