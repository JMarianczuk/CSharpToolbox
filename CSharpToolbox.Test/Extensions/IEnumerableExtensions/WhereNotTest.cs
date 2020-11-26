using System;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.IEnumerableExtensions
{
    [TestClass]
    public class WhereNotTest : IEnumerableResultType
    {
        private Func<int, bool> _filter;
        protected void AFilterThatAllowsEvenNumbers()
        {
            _filter = x => x % 2 == 0;
        }

        protected void AFilterThatAllowsOddNumbers()
        {
            _filter = x => x % 2 == 0;
        }

        protected void AFilterThatAllowsAnyNumber()
        {
            _filter = _ => true;
        }
        protected void AFilterThatAllowsNoNumber()
        {
            _filter = _ => false;
        }

        protected void WhereNotIsInvoked()
        {
            Result = Numbers.WhereNot(_filter);
        }

        [TestMethod]
        public void BasicFilter()
        {
            Given(NumbersFromOneToTen, AFilterThatAllowsEvenNumbers);
            When(WhereNotIsInvoked);
            Then(TheResultIsNotEmpty, TheResultIs(1, 3, 5, 7, 9));
        }

        [TestMethod]
        public void AlwaysTrueFilter()
        {
            Given(NumbersFromOneToTen, AFilterThatAllowsAnyNumber);
            When(WhereNotIsInvoked);
            Then(TheResultIsEmpty);
        }

        [TestMethod]
        public void AlwaysFalseFilter()
        {
            Given(NumbersFromOneToTen, AFilterThatAllowsNoNumber);
            When(WhereNotIsInvoked);
            Then(TheResultIsNotEmpty, TheResultIs(1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        }

        [TestMethod]
        public void EmptyCollectionTest()
        {
            Given(AnEmptyCollection, AFilterThatAllowsNoNumber);
            When(WhereNotIsInvoked);
            Then(TheResultIsEmpty);
        }
    }
}