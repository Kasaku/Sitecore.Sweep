using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class RemoveEmptyNodesTests
	{
		[Test]
		public void SingleEmptyNode()
		{
			var tester = new CleanerTester<RemoveEmptyNodes>();

			tester.AssertParsedHtml("<p>content</p><p></p>", "<p>content</p>");
		}

		[Test]
		public void MultipleEmptyNodes()
		{
			var tester = new CleanerTester<RemoveEmptyNodes>();

			tester.AssertParsedHtml("<p></p><p>content</p><p></p>", "<p>content</p>");
		}

		[Test]
		public void OnlyEmptyNodes()
		{
			var tester = new CleanerTester<RemoveEmptyNodes>();

			tester.AssertParsedHtml("<p></p><p></p>", "");
		}

		[Test]
		public void SingleEmptyNodeWithIgnoredElement()
		{
			var tester = new CleanerTester<RemoveEmptyNodes>();

			var cleaner = new RemoveEmptyNodes()
			{
				IgnoredElements = "p"
			};

			tester.AssertParsedHtml(cleaner, "<p>content</p><p></p>", "<p>content</p><p></p>");
		}

		[Test]
		public void EmptyNodesWithMultipleIgnoredElement()
		{
			var tester = new CleanerTester<RemoveEmptyNodes>();

			var cleaner = new RemoveEmptyNodes()
			{
				IgnoredElements = "p|div"
			};

			tester.AssertParsedHtml(cleaner, "<p>content</p><div></div><p></p>", "<p>content</p><div></div><p></p>");
		}
	}
}
