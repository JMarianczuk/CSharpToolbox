using System;
using System.Collections.Generic;
using FluentAssertions;

namespace CSharpToolbox.Test.Extensions.IEnumerableExtensions
{
    public abstract class IEnumerableResultType : IEnumerableExtensionsTestBase
    {
        protected IEnumerable<int> Result;

        protected Action TheResultIs(params int[] numbers)
        {
            return () => Result.Should().BeEquivalentTo(numbers);
        }

        protected void TheResultIsEmpty()
        {
            Result.Should().BeEmpty();
        }

        protected void TheResultIsNotEmpty()
        {
            Result.Should().NotBeEmpty();
        }
    }
}