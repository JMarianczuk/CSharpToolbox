using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    public class PeekTests : DeQueueTestBase
    {
        [TestMethod]
        public void PeekFrontTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(TheFrontIsPeekedAt);
            Then(ThePeekedAtNumberIs(1));
        }

        [TestMethod]
        public void PeekBackTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(TheBackIsPeekedAt);
            Then(ThePeekedAtNumberIs(4));
        }

        [TestMethod]
        public void PeekFrontAfterPushFront()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5))
                .And(TheFrontIsPeekedAt);
            Then(ThePeekedAtNumberIs(5));
        }

        [TestMethod]
        public void PeekFrontAfterPushBack()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5))
                .And(TheFrontIsPeekedAt);
            Then(ThePeekedAtNumberIs(1));
        }

        [TestMethod]
        public void PeekBackAfterPushFront()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5))
                .And(TheBackIsPeekedAt);
            Then(ThePeekedAtNumberIs(4));
        }

        [TestMethod]
        public void PeekBackAfterPushBack()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5))
                .And(TheBackIsPeekedAt);
            Then(ThePeekedAtNumberIs(5));
        }

        [TestMethod]
        public void PeekBackAfterTwoPushes()
        {
            Given(ADeQueue);
            When(ANumberIsPushedFront(1))
                .And(ANumberIsPushedBack(2))
                .And(TheBackIsPeekedAt);
            Then(ThePeekedAtNumberIs(2));
        }

        [TestMethod]
        public void TryPeekFrontTest() //TODO
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(TryPeekFrontIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(1));
        }

        [TestMethod]
        public void TryPeekBackTest()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(TryPeekBackIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(4));
        }

        [TestMethod]
        public void TryPeekFrontAfterPushFront()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5))
                .And(TryPeekFrontIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(5));
        }

        [TestMethod]
        public void TryPeekFrontAfterPushBack()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5))
                .And(TryPeekFrontIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(1));
        }

        [TestMethod]
        public void TryPeekBackAfterPushFront()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedFront(5))
                .And(TryPeekBackIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(4));
        }

        [TestMethod]
        public void TryPeekBackAfterPushBack()
        {
            Given(ADeQueueContaining(1, 2, 3, 4));
            When(ANumberIsPushedBack(5))
                .And(TryPeekBackIsInvoked);
            Then(ThePeekWasSuccessful)
                .And(ThePeekedAtNumberIs(5));
        }

        [TestMethod]
        public void TryPeekFrontEmptyQueue()
        {
            Given(ADeQueue);
            When(TryPeekFrontIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekFrontEmptyQueueWithCapacity()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(TryPeekFrontIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekFrontAfterPopFront()
        {
            Given(ADeQueueContaining(1));
            When(ANumberIsPoppedFront)
                .And(TryPeekFrontIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekFrontAfterPopBack()
        {
            Given(ADeQueueContaining(1));
            When(ANumberIsPoppedBack)
                .And(TryPeekFrontIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekBackEmptyQueue()
        {
            Given(ADeQueue);
            When(TryPeekBackIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekBackEmptyQueueWithCapacity()
        {
            Given(ADeQueueWithInitialCapacity(100));
            When(TryPeekBackIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekBackAfterPopFront()
        {
            Given(ADeQueueContaining(1));
            When(ANumberIsPoppedFront)
                .And(TryPeekBackIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void TryPeekBackAfterPopBack()
        {
            Given(ADeQueueContaining(1));
            When(ANumberIsPoppedBack)
                .And(TryPeekBackIsInvoked);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void PeekFront_Illegal()
        {
            Given(ADeQueue);
            When(TheFrontIsPeekedAt);
            Then(ThePeekWasNotSuccessful);
        }

        [TestMethod]
        public void PeekBack_Illegal()
        {
            Given(ADeQueue);
            When(TheBackIsPeekedAt);
            Then(ThePeekWasNotSuccessful);
        }
    }
}