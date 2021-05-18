using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class PopTests : DeQueueTestBase
    {
        [TestMethod]
        public void PopFrontTest()
        {
            int number = 0;
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => ANumberIsPoppedFront(out number));
            Then(() => number.Should().Be(1));
        }

        [TestMethod]
        public void PopFrontCountTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPoppedFront);
            Then(TheCountIs(3));
        }

        [TestMethod]
        public void PopBackTest()
        {
            int number = 0;
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => ANumberIsPoppedBack(out number));
            Then(() => number.Should().Be(4));
        }

        [TestMethod]
        public void PopBackCountTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPoppedBack);
            Then(TheCountIs(3));
        }

        [TestMethod]
        public void PushFrontBackPopBackTest()
        {
            Given(ADeQueue);
            When(NumbersArePushedFront(1))
                .And(NumbersArePushedBack(2))
                .And(ANumberIsPoppedBack);
            Then(TheQueueContains(1));
        }

        [TestMethod]
        public void PushFrontBackPopFrontTest()
        {
            Given(ADeQueue);
            When(NumbersArePushedFront(1))
                .And(NumbersArePushedBack(2))
                .And(ANumberIsPoppedFront);
            Then(TheQueueContains(2));
        }

        [TestMethod]
        public void TryPopFrontTest_EmptyQueue()
        {
            bool wasPopped = true;
            Given(ADeQueue);
            When(() => TryPopFront(out wasPopped, out _));
            Then(() => wasPopped.Should().BeFalse());
        }

        [TestMethod]
        public void TryPopFrontTest_NonEmptyQueue()
        {
            bool wasPopped = false;
            int number = 0;
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => TryPopFront(out wasPopped, out number));
            Then(() => wasPopped.Should().BeTrue())
                .And(() => number.Should().Be(1));
        }

        [TestMethod]
        public void TryPopFrontCountTest_NonEmptyQueue()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => TryPopFront(out _, out _));
            Then(TheCountIs(3));
        }

        [TestMethod]
        public void TryPopBackTest_EmptyQueue()
        {
            bool wasPopped = true;
            Given(ADeQueue);
            When(() => TryPopBack(out wasPopped, out _));
            Then(() => wasPopped.Should().BeFalse());
        }

        [TestMethod]
        public void TryPopBackTest_NonEmptyQueue()
        {
            bool wasPopped = false;
            int number = 0;
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => TryPopBack(out wasPopped, out number));
            Then(() => wasPopped.Should().BeTrue())
                .And(() => number.Should().Be(4));
        }

        [TestMethod]
        public void TryPopBackCountTest_NonEmptyQueue()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(() => TryPopBack(out _, out _));
            Then(TheCountIs(3));
        }

        [TestMethod]
        public void PopFront_Illegal()
        {
            Given(ADeQueue);
            When(ANumberIsPoppedFront);
            Then(ThePopThrewAnException);
        }

        [TestMethod]
        public void PopBack_Illegal()
        {
            Given(ADeQueue);
            When(ANumberIsPoppedBack);
            Then(ThePopThrewAnException);
        }
    }
}