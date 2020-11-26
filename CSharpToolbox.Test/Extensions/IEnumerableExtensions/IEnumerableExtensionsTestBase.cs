using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace CSharpToolbox.Test.Extensions.IEnumerableExtensions
{
    public abstract class IEnumerableExtensionsTestBase : GivenWhenThen
    {
        protected IEnumerable<int> Numbers;

        protected void NumbersFromOneToTen()
        {
            Numbers = Enumerable.Range(1, 10);
        }

        protected void AnEmptyCollection()
        {
            Numbers = Enumerable.Empty<int>();
        }
    }
}