using System;
using System.Collections.Generic;
using System.Linq;
using CSharpToolbox.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.IEnumeratorExtensions
{
    [TestClass]
    public class ConcatTest : IEnumeratorExtensionsTestBase
    {
        protected IEnumerator<int> AnotherEnumerator;

        protected IEnumerator<int> ConcatenatedEnumerator;

        protected Action AnotherEnumeratorFor(params int[] numbers)
        {
            return () => AnotherEnumerator = numbers.AsEnumerable().GetEnumerator();
        }

        protected void TheEnumeratorsAreConcatenated()
        {
            ConcatenatedEnumerator = Enumerator.Concat(AnotherEnumerator);
        }

        protected Action TheConcatenationEnumeratesTo(params int[] numbers)
        {
            return () =>
            {
                int count = 0;
                while (ConcatenatedEnumerator.MoveNext())
                {
                    count.Should().BeLessThan(numbers.Length);
                    ConcatenatedEnumerator.Current.Should().Be(numbers[count]);
                    count += 1;
                }
                count.Should().Be(numbers.Length);
            };
        }

        [TestMethod]
        public void WhenTest_EnumeratingTo()
        {
            int[] numbers = { 1, 2, 3, 4 };
            ConcatenatedEnumerator = numbers.AsEnumerable().GetEnumerator();
            Then(TheConcatenationEnumeratesTo(numbers));
        }

        [TestMethod]
        public void TwoEmptyEnumeratorsTest()
        {
            Given(AnEnumeratorFor(AnEmptyList))
                .And(AnotherEnumeratorFor(AnEmptyList));
            When(TheEnumeratorsAreConcatenated);
            Then(TheConcatenationEnumeratesTo(AnEmptyList));
        }

        [TestMethod]
        public void FirstEnumeratorEmptyTest()
        {
            Given(AnEnumeratorFor(AnEmptyList))
                .And(AnotherEnumeratorFor(1, 2, 3, 4));
            When(TheEnumeratorsAreConcatenated);
            Then(TheConcatenationEnumeratesTo(1, 2, 3, 4));
        }

        [TestMethod]
        public void SecondEnumeratorEmptyTest()
        {
            Given(AnEnumeratorFor(5, 6, 7, 8))
                .And(AnotherEnumeratorFor(AnEmptyList));
            When(TheEnumeratorsAreConcatenated);
            Then(TheConcatenationEnumeratesTo(5, 6, 7, 8));
        }

        [TestMethod]
        public void BothEnumeratorsWithNumbersTest()
        {
            Given(AnEnumeratorFor(5, 6, 7, 8))
                .And(AnotherEnumeratorFor(1, 2, 3, 4));
            When(TheEnumeratorsAreConcatenated);
            Then(TheConcatenationEnumeratesTo(5, 6, 7, 8, 1, 2, 3, 4));
        }
    }
}