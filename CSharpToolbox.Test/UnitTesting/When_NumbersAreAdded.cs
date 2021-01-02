using System.Linq;
using CSharpToolbox.Test.UnitTesting.Given;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.UnitTesting
{
    [TestClass]
    public class When_NumbersAreAdded : GivenWhenThenBaseTestBase
    {
        protected int Result;
        protected void When()
        {
            Result = Numbers.Sum();
        }

        [TestMethod]
        [Ignore]
        public void EmptyNumbersSum()
        {
            //Given<AnEmptyList>();
            When();
            Result.Should().Be(0);
        }

        [TestMethod]
        public void ActualNumbersSum()
        {
            Given<Numbers>(1, 2, 3, 4);
            When();
            Result.Should().Be(10);
        }
    }
}