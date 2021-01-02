using System;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    [TestClass]
    public class TrimTest : TrimTestBase
    {
        protected override Action TheStringIsTrimmedBy(string trim)
        {
            return () => Result = Text.Trim(trim);
        }

        public override bool TrimStart => true;
        public override bool TrimEnd => true;

        [TestMethod]
        public void SingleCharTrim()
        {
            Given(AString("abca"));
            When(TheStringIsTrimmedBy("a"));
            Then(TheResultIs("bc"));
        }

        [TestMethod]
        public void MultipleCharsTrim()
        {
            Given(AString("ab-cd-ab"));
            When(TheStringIsTrimmedBy("ab"));
            Then(TheResultIs("-cd-"));
        }

        [TestMethod]
        public void CompleteTrim()
        {
            Given(AString("abab"));
            When(TheStringIsTrimmedBy("ab"));
            Then(TheResultIsEmpty);
        }

        [TestMethod]
        public void OnlyCompleteMultiCharacterTrim()
        {
            Given(AString("aba-cdcd-bab"));
            When(TheStringIsTrimmedBy("ab"));
            Then(TheResultIs("a-cdcd-b"));
        }
    }
}