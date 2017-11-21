using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
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