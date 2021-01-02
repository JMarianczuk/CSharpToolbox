using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class CopyToTest : DeQueueTestBase
    {
        protected int[] Array;

        protected Action AnArrayOfSize(int size, int defaultValue = -1)
        {
            return () => Array = Enumerable.Repeat(defaultValue, size).ToArray();
        }

        protected void TheQueueIsCopiedToTheArray()
        {
            Queue.CopyTo(Array, 0);
        }

        protected Action TheQueueIsCopiedToTheArrayAtIndex(int index)
        {
            return () => Queue.CopyTo(Array, index);
        }

        protected Action TheArrayContains(params int[] numbers)
        {
            return () => Array.Should().BeEquivalentTo(numbers);
        }

        [TestMethod]
        public void StandardCopyToTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4), AnArrayOfSize(4));
            When(TheQueueIsCopiedToTheArray);
            Then(TheArrayContains(1, 2, 3, 4));
        }

        [TestMethod]
        public void PartlyFilledCopyToTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(4));
            When(NumbersArePushedBack(1, 2, 3, 4), TheQueueIsCopiedToTheArray);
            Then(TheArrayContains(1, 2, 3, 4));
        }

        [TestMethod]
        public void LooparoundCopyToTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(4));
            When(NumbersArePushedBack(1, 2), NumbersArePushedFront(3, 4), TheQueueIsCopiedToTheArray);
            Then(TheArrayContains(4, 3, 1, 2));
        }

        [TestMethod]
        public void CompleteLooparoundCopyToTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(6));
            When(NumbersArePushedBack(1, 2, 3), NumbersArePushedFront(4, 5, 6), TheQueueIsCopiedToTheArray);
            Then(TheArrayContains(6, 5, 4, 1, 2, 3));
        }

        [TestMethod]
        public void StandardCopyToAtIndexTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4), AnArrayOfSize(6, -1));
            When(TheQueueIsCopiedToTheArrayAtIndex(2));
            Then(TheArrayContains(-1, -1, 1, 2, 3, 4));
        }

        [TestMethod]
        public void PartlyFilledCopyToAtIndexTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(6, 7));
            When(NumbersArePushedBack(1, 2, 3, 4), TheQueueIsCopiedToTheArrayAtIndex(2));
            Then(TheArrayContains(7, 7, 1, 2, 3, 4));
        }

        [TestMethod]
        public void LooparoundCopyToAtIndexTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(8, 0));
            When(NumbersArePushedBack(1, 2), NumbersArePushedFront(3, 4), TheQueueIsCopiedToTheArrayAtIndex(4));
            Then(TheArrayContains(0, 0, 0, 0, 4, 3, 1, 2));
        }

        [TestMethod]
        public void CompleteLooparoundCopyToAtIndexTest()
        {
            Given(ADeQueueWithInitialCapacity(6), AnArrayOfSize(7, -1));
            When(NumbersArePushedBack(1, 2, 3), NumbersArePushedFront(4, 5, 6), TheQueueIsCopiedToTheArrayAtIndex(0));
            Then(TheArrayContains(6, 5, 4, 1, 2, 3, -1));
        }


    }
}