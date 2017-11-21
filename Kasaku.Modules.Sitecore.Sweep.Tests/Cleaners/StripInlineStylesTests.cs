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

	[TestFixture]
	public class RemoveNonbreakingSpacesTests
	{
		[Test]
		public void NonbreakingSpaces()
		{
			var tester = new CleanerTester<RemoveNonbreakingSpaces>();

			tester.AssertParsedHtml("<p>I like to use &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this for padding</p>", "<p>I like to use this for padding</p>");
		}
	}
}
