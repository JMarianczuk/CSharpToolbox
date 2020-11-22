using MoreLinq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test
{
    public abstract class GivenWhenThen
    {
        private static void Invoke(Action action) => action?.Invoke();
        protected void Given(params Action[] givenActions)
        {
            givenActions.ForEach(Invoke);
        }

        protected void When(params Action[] whenActions)
        {
            whenActions.ForEach(Invoke);
        }

        protected void Then(params Action[] thenActions)
        {
            thenActions.ForEach(Invoke);
        }
    }
}