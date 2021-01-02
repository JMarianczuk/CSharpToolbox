using System;
using CSharpToolbox.Collections;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.InitializableCollection
{
    public abstract class InitializableCollectionTestBase : GivenWhenThen
    {
        protected InitializableCollectionBase<int> Initializable;

        protected abstract void AnInitializableCollection();

        protected Action AnElementIsAddedDirectly(int number)
        {
            return () => Initializable.Add(number);
        }

        protected Action TheCollectionContains(params int[] numbers)
        {
            return () => Initializable.Should().BeEquivalentTo(numbers);
        }

        [TestMethod]
        public void DirectElementAddTest()
        {
            Given(AnInitializableCollection);
            When(AnElementIsAddedDirectly(5));
            Then(TheCollectionContains(5));
        }
    }
}