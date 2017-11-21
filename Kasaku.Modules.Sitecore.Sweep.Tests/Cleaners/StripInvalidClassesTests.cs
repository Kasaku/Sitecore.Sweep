using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using Kasaku.Sitecore.Modules.Sweep.Pipelines.Clean;
using NUnit.Framework;

namespace Kasaku.Modules.Sitecore.Sweep.Tests.Cleaners
{
	[TestFixture]
	public class StripInvalidClassesTests
	{
		[Test]
		public void SingleInvalidClass()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid\">content</p>", "<p>content</p>");
		}

		[Test]
		public void SingleInvalidClassWithValidClassPresent()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid valid\">content</p>", "<p class=\"valid\">content</p>");
		}

		[Test]
		public void SingleInvalidClassWithValidClassesPresent()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");

			tester.AssertParsedHtml(cleaner, "<p class=\"valid invalid alsovalid\">content</p>", "<p class=\"valid alsovalid\">content</p>");
		}

		[Test]
		public void MultipleInvalidClasses()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");
			cleaner.InvalidClasses.Add("invalid2");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid invalid2\">content</p>", "<p>content</p>");
		}

		[Test]
		public void SingleValidClass()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.ValidClasses.Add("valid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid\">content</p>", "<p>content</p>");
		}

		[Test]
		public void SingleValidClassWithValidClassPresent()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.ValidClasses.Add("valid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid valid\">content</p>", "<p class=\"valid\">content</p>");
		}

		[Test]
		public void SingleValidClassWithValidClassesPresent()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.ValidClasses.Add("valid");
			cleaner.ValidClasses.Add("alsovalid");

			tester.AssertParsedHtml(cleaner, "<p class=\"valid invalid alsovalid\">content</p>", "<p class=\"valid alsovalid\">content</p>");
		}

		[Test]
		public void MultipleOccurencesOfInvalidClass()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid\">content</p><div class=\"invalid\"><p class=\"invalid\">content</p></div>", "<p>content</p><div><p>content</p></div>");
		}

		[Test]
		public void InvalidClassesTakenPreferenceIfBothSpecified()
		{
			var tester = new CleanerTester<StripInvalidClasses>();

			var cleaner = new StripInvalidClasses();
			cleaner.InvalidClasses.Add("invalid");
			cleaner.ValidClasses.Add("valid");

			tester.AssertParsedHtml(cleaner, "<p class=\"invalid unspecified\">content</p>", "<p class=\"unspecified\">content</p>");
		}
	}
}
