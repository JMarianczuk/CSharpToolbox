using System;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.IEnumerableExtensions
{
    [TestClass]
    public class NoneTest : BoolResultType
    {
        private Func<int, bool> _filter;

        protected void AFilterThatAllowsAnyNumber()
        {
            _filter = _ => true;
        }

        protected Action AFilterThatIsTrueFor(int number)
        {
            return () =>
            {
                _filter = x => x == number;
            };
        }

        protected void NoneIsInvoked()
        {
            Result = Numbers.None(_filter);
        }

        [TestMethod]
        public void EmptyCollectionTest()
        {
            Given(AnEmptyCollection)
                .And(AFilterThatAllowsAnyNumber);
            When(NoneIsInvoked);
            Then(TheResultIsTrue);
        }

        [TestMethod]
        public void CollectionDoesNotContainFilterTest()
        {
            Given(NumbersFromOneToTen)
                .And(AFilterThatIsTrueFor(42));
            When(NoneIsInvoked);
            Then(TheResultIsTrue);
        }

        [TestMethod]
        public void CollectionDoesContainFilterTest()
        {
            Given(NumbersFromOneToTen)
                .And(AFilterThatIsTrueFor(3));
            When(NoneIsInvoked);
            Then(TheResultIsFalse);
        }
    }
}