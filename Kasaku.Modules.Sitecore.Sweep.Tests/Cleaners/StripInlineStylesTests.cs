using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class StripInlineStylesTests
	{
		[Test]
		public void SingleInlineStyle()
		{
			var tester = new CleanerTester<StripInlineStyles>();

			tester.AssertParsedHtml("<p style=\"margin-top: 5px\">content</p>", "<p>content</p>");
		}

		[Test]
		public void MultipleInlineStyle()
		{
			var tester = new CleanerTester<StripInlineStyles>();

			tester.AssertParsedHtml("<p style=\"margin-top: 5px\">content</p><p style=\"margin-top: 5px\">content</p>", "<p>content</p><p>content</p>");
		}
	}
}
