using CSharpToolbox.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class CapacityTests : DeQueueTestBase
    {
        [TestMethod]
        public void DefaultQueueCapacity()
        {
            Given(ADeQueue);
            Then(TheCapacityIsZero);
        }

        [TestMethod]
        public void QueueCapacityWithItems()
        {
            Given(ADeQueue);
            When(NumbersArePushedFront(1, 2));
            Then(TheCapacityIsNotZero);
        }

        [TestMethod]
        public void TrimTest()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(TheQueueIsTrimmed);
            Then(TheCapacityIsLessThan(100));
        }

        [TestMethod]
        public void AutoShrinkTestPopFront()
        {
            Given(AnAutoShrinkingDeQueueWithCapacity(100));
            When(NumbersArePushedFront(1, 2))
                .And(ANumberIsPoppedFront);
            Then(TheCapacityIsLessThan(100));
        }

        [TestMethod]
        public void AutoShrinkTestPopBack()
        {
            Given(AnAutoShrinkingDeQueueWithCapacity(100));
            When(NumbersArePushedFront(1, 2))
                .And(ANumberIsPoppedBack);
            Then(TheCapacityIsLessThan(100));
        }

        [TestMethod]
        public void NoAutoShrinkTestPopFront()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(NumbersArePushedFront(1, 2))
                .And(ANumberIsPoppedFront);
            Then(TheCapacityIs(100));
        }

        [TestMethod]
        public void TrimTest_NumbersAreRetained()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(NumbersArePushedBack(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                .And(NumbersArePushedFront(17, 18))
                .And(TheQueueIsTrimmed);
            Then(TheQueueContains(18, 17, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
        }

        [TestMethod]
        public void MinimalCapacityTest()
        {
            const int minimumNonZeroCapacity = 4;
            Given(ADeQueueWithInitialCapacity(minimumNonZeroCapacity));
            When(NumbersArePushedBack(1))
                .And(TheQueueIsTrimmed);
            Then(TheCapacityIs(minimumNonZeroCapacity));
        }

        [TestMethod]
        public void PeekBackAfterShrinkTest()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(NumbersArePushedBack(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                .And(TheQueueIsTrimmed)
                .And(TheBackIsPeekedAt);
            Then(ThePeekedAtNumberIs(10));
        }

        [TestMethod]
        public void PeekFrontAfterShrinkTest()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(NumbersArePushedBack(1, 2, 3, 4, 5, 6, 7, 8, 9, 10))
                .And(TheQueueIsTrimmed)
                .And(TheFrontIsPeekedAt);
            Then(ThePeekedAtNumberIs(1));
        }
    }
}