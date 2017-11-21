using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class ConvertStrongParagraphToHeaderTests
	{
		[Test]
		public void DefaultReplacement()
		{
			var tester = new CleanerTester<ConvertStrongParagraphToHeader>();

			tester.AssertParsedHtml("<p><strong>This is really a header!</strong></p>", "<h4>This is really a header!</h4>");
		}

		[Test]
		public void DefaultReplacementWithBoldElement()
		{
			var tester = new CleanerTester<ConvertStrongParagraphToHeader>();

			tester.AssertParsedHtml("<p><b>This is really a header!</b></p>", "<h4>This is really a header!</h4>");
		}

		[Test]
		public void NormalParagraphRemains()
		{
			var tester = new CleanerTester<ConvertStrongParagraphToHeader>();

			tester.AssertParsedHtml("<p>This is a regular paragraph</p>", "<p>This is a regular paragraph</p>");
		}

		[Test]
		public void CustomReplacement()
		{
			var tester = new CleanerTester<ConvertStrongParagraphToHeader>();

			var cleaner = new ConvertStrongParagraphToHeader
			{
				ReplacementElement = "h2"				
			};

			tester.AssertParsedHtml(cleaner, "<p><strong>This is really a header!</strong></p>", "<h2>This is really a header!</h2>");
		}
	}
}