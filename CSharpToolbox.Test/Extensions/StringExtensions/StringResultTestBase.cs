using System;
using FluentAssertions;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    public abstract class StringResultTestBase : StringExtensionsTestBase
    {
        protected string Result;

        protected Action TheResultIs(string result)
        {
            return () => Result.Should().Be(result);
        }

        protected void TheResultIsEmpty()
        {
            Result.Should().BeEmpty();
        }
    }
}