using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class AsEnumerableTest : DeQueueTestBase
    {
        [TestMethod]
        public void EnumerableTest_EmptyCollection()
        {
            Given(ADeQueue);
            Then(TheQueueContains(Nothing));
        }

        [TestMethod]
        public void EnumerableTest_InitialCollection()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            Then(TheQueueContains(1, 2, 3, 4));
        }

        [TestMethod]
        public void InsertedNumbersBackTest()
        {
            Given(ADeQueue);
            When(NumbersArePushedBack(1, 2, 3, 4));
            Then(TheQueueContains(1, 2, 3, 4));
        }

        [TestMethod]
        public void InsertedNumbersFrontTest()
        {
            Given(ADeQueue);
            When(NumbersArePushedFront(1, 2, 3, 4));
            Then(TheQueueContains(4, 3, 2, 1));
        }

        [TestMethod]
        public void InsertedAndPoppedBackNumbersTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPoppedBack);
            Then(TheQueueContains(1, 2, 3));
        }

        [TestMethod]
        public void InsertedAndPoppedFrontNumbersTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPoppedFront);
            Then(TheQueueContains(2, 3, 4));
        }

        [TestMethod]
        public void LooparoundTest()
        {
            Given(ADeQueueWithInitialCapacity(6));
            When(NumbersArePushedBack(1, 2), NumbersArePushedFront(3, 4));
            Then(TheQueueContains(4, 3, 1, 2));
        }

        [TestMethod]
        public void FullLooparoundTest()
        {
            Given(ADeQueueWithInitialCapacity(6));
            When(NumbersArePushedBack(1, 2, 3), NumbersArePushedFront(4, 5, 6));
            Then(TheQueueContains(6, 5, 4, 1, 2, 3));
        }
    }
}