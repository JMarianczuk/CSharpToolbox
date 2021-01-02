using System;
using CSharpToolbox.Test.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    public abstract class TrimTestBase : StringResultTestBase
    {
        protected abstract Action TheStringIsTrimmedBy(string text);
        public abstract bool TrimStart { get; }
        public abstract bool TrimEnd { get; }

        [TestMethod]
        public void EmptyStringEmptyTrailing()
        {
            Given(AnEmptyString);
            When(TheStringIsTrimmedBy(string.Empty));
            Then(TheResultIsEmpty);
        }

        [TestMethod]
        public void EmptyStringTrim()
        {
            Given(AnEmptyString);
            When(TheStringIsTrimmedBy("abcd"));
            Then(TheResultIsEmpty);
        }

        [TestMethod]
        public void EmptyTrimTest()
        {
            Given(AString("abcd"));
            When(TheStringIsTrimmedBy(""));
            Then(TheResultIs("abcd"));
        }

        [ExtendedTestMethod]
        [ExecuteIf(nameof(TrimStart))]
        public void SingleCharTrimFront()
        {
            Given(AString("abcd"));
            When(TheStringIsTrimmedBy("a"));
            Then(TheResultIs("bcd"));
        }

        [ExtendedTestMethod]
        [ExecuteIf(nameof(TrimEnd))]
        public void SingleCharTrimBack()
        {
            Given(AString("abcd"));
            When(TheStringIsTrimmedBy("d"));
            Then(TheResultIs("abc"));
        }

        [ExtendedTestMethod]
        [ExecuteIf(nameof(TrimStart))]
        public void MultipleCharsTrimFront()
        {
            Given(AString("abcd"));
            When(TheStringIsTrimmedBy("ab"));
            Then(TheResultIs("cd"));
        }

        [ExtendedTestMethod]
        [ExecuteIf(nameof(TrimEnd))]
        public void MultipleCharsTrimBack()
        {
            Given(AString("abcd"));
            When(TheStringIsTrimmedBy("cd"));
            Then(TheResultIs("ab"));
        }
    }
}