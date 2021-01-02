using System;
using System.Linq;
using CSharpToolbox.Collections;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    public class DeQueueTestBase : GivenWhenThen
    {
        protected DoubleEndedQueue<int> Queue;
        protected Exception PopException;
        protected static readonly int[] Nothing = { };

        [TestInitialize]
        public virtual void Initialize()
        {
            Queue = null;
            PopException = null;
        }

        protected void ADeQueue()
        {
            Queue = new DoubleEndedQueue<int>();
        }

        protected void AnAutoShrinkingDeQueue()
        {
            Queue = new DoubleEndedQueue<int>(true);
        }

        protected Action ADeQueueWithInitialCapacity(int capacity)
        {
            return () => Queue = new DoubleEndedQueue<int>(capacity);
        }

        protected Action AnAutoShrinkingDeQueueWithCapacity(int capacity)
        {
            return () => Queue = new DoubleEndedQueue<int>(capacity, true);
        }

        protected Action ADeQueueContaining(params int[] numbers)
        {
            return () => Queue = new DoubleEndedQueue<int>(numbers);
        }

        protected Action NumbersArePushedFront(params int[] numbers)
        {
            return () => numbers.ForEach(Queue.PushFront);
        }

        protected Action NumbersArePushedBack(params int[] numbers)
        {
            return () => numbers.ForEach(Queue.PushBack);
        }

        protected void ANumberIsPoppedFront()
        {
            try
            {
                Queue.PopFront();
            }
            catch (Exception e)
            {
                PopException = e;
            }
        }

        protected void ANumberIsPoppedBack()
        {
            try
            {
                Queue.PopBack();
            }
            catch (Exception e)
            {
                PopException = e;
            }
        }

        protected void ThePopThrewAnException()
        {
            PopException.Should().NotBeNull();
        }

        protected void ANumberIsPoppedFront(out int number)
        {
            number = Queue.PopFront();
        }

        protected void ANumberIsPoppedBack(out int number)
        {
            number = Queue.PopBack();
        }

        protected void TryPopFront(out bool wasPopped, out int number)
        {
            wasPopped = Queue.TryPopFront(out number);
        }

        protected void TryPopBack(out bool wasPopped, out int number)
        {
            wasPopped = Queue.TryPopBack(out number);
        }

        protected Action ANumberIsPushedFront(int number)
        {
            return () => Queue.PushFront(number);
        }

        protected Action ANumberIsPushedBack(int number)
        {
            return () => Queue.PushBack(number);
        }

        protected void TheQueueIsTrimmed()
        {
            Queue.TrimExcess();
        }

        protected void TheCapacityIsZero()
        {
            Queue.Capacity.Should().Be(0);
        }

        protected void TheCapacityIsNotZero()
        {
            Queue.Capacity.Should().NotBe(0);
        }

        protected Action TheCapacityIs(int capacity)
        {
            return () => Queue.Capacity.Should().Be(capacity);
        }

        protected Action TheCapacityIsLessThan(int upperBound)
        {
            return () => Queue.Capacity.Should().BeLessThan(upperBound);
        }

        protected Action TheCapacityIsGreaterThan(int lowerBound)
        {
            return () => Queue.Capacity.Should().BeGreaterThan(lowerBound);
        }

        protected Action TheQueueContains(params int[] numbers)
        {
            return () => Queue.Should().BeEquivalentTo(numbers);
        }

        protected Action TheCountIs(int number)
        {
            return () => Queue.Count.Should().Be(number);
        }

        protected Action TheFirstNumberIs(int number)
        {
            return () => Queue.First().Should().Be(number);
        }

        protected Action TheLastNumberIs(int number)
        {
            return () => Queue.Last().Should().Be(number);
        }
    }
}