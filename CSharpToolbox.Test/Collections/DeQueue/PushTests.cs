using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class PushTests : DeQueueTestBase
    {
        [TestMethod]
        public void PushFrontTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5));
            Then(TheQueueContains(5, 1, 2, 3, 4));
        }

        [TestMethod]
        public void PushFrontCountTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5));
            Then(TheCountIs(5));
        }

        [TestMethod]
        public void PushBackTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5));
            Then(TheQueueContains(1, 2, 3, 4, 5));
        }

        [TestMethod]
        public void PushBackCountTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5));
            Then(TheCountIs(5));
        }
    }
}