using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToolbox.Test.Extensions.IEnumeratorExtensions
{
    public abstract class IEnumeratorExtensionsTestBase : GivenWhenThen
    {
        protected IEnumerator<int> Enumerator;

        protected static readonly int[] AnEmptyList = { };

        protected Action AnEnumeratorFor(params int[] numbers)
        {
            return () => Enumerator = numbers.AsEnumerable().GetEnumerator();
        }
    }
}