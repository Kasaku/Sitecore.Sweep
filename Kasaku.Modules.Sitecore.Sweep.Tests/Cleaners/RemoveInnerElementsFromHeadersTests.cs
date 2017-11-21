using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class RemoveInnerElementsFromHeadersTests
	{
		[Test]
		public void HeaderWithNoInnerElements()
		{
			var tester = new CleanerTester<RemoveInnerElementsFromHeaders>();

			tester.AssertParsedHtml("<h1>Regular header</h1>", "<h1>Regular header</h1>");
		}

		[Test]
		public void HeaderWithInnerElements()
		{
			var tester = new CleanerTester<RemoveInnerElementsFromHeaders>();

			tester.AssertParsedHtml("<h1><strong>Header with inner element</strong></h1>", "<h1>Header with inner element</h1>");
		}

		[Test]
		public void HeaderWithNestedInnerElements()
		{
			var tester = new CleanerTester<RemoveInnerElementsFromHeaders>();

			tester.AssertParsedHtml("<h1><strong>Header with <em>inner elements</em></strong></h1>", "<h1>Header with inner elements</h1>");
		}

		[Test]
		public void NonHeadersWithInnerElements()
		{
			var tester = new CleanerTester<RemoveInnerElementsFromHeaders>();

			tester.AssertParsedHtml("<h1><strong>Header with inner element</strong></h1><p><strong>Strong paragraph</strong></p>", "<h1>Header with inner element</h1><p><strong>Strong paragraph</strong></p>");
		}

		[Test]
		public void VariousHeaderElements()
		{
			var tester = new CleanerTester<RemoveInnerElementsFromHeaders>();

			tester.AssertParsedHtml("<h1><strong>Header with inner element</strong></h1>", "<h1>Header with inner element</h1>");
			tester.AssertParsedHtml("<h2><strong>Header with inner element</strong></h2>", "<h2>Header with inner element</h2>");
			tester.AssertParsedHtml("<h3><strong>Header with inner element</strong></h3>", "<h3>Header with inner element</h3>");
			tester.AssertParsedHtml("<h4><strong>Header with inner element</strong></h4>", "<h4>Header with inner element</h4>");
			tester.AssertParsedHtml("<h5><strong>Header with inner element</strong></h5>", "<h5>Header with inner element</h5>");
			tester.AssertParsedHtml("<h6><strong>Header with inner element</strong></h6>", "<h6>Header with inner element</h6>");
		}

	}
}