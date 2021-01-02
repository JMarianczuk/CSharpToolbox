using MoreLinq;
using System;
using System.Collections.Generic;

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

    public abstract class GivenWhenThenBase<TBase, TProperty> where TBase : class
    {
        protected void Given<TGiven>() where TGiven : IGiven<TBase>, new()
        {
            new TGiven().Given(this as TBase);
        }

        protected void Given<TGiven>(TProperty property) where TGiven : IGiven<TBase, TProperty>, new ()
        {
            new TGiven().Given(this as TBase, property);
        }

        protected void When<TWhen>() where TWhen : IWhen<TBase>, new()
        {
            new TWhen().When(this as TBase);
        }
    }

    public interface IGiven<in TBase>
    {
        void Given(TBase testBase);
    }

    public interface IGiven<in TBase, in TProperty>
    {
        void Given(TBase testBase, TProperty property);
    }

    public interface IWhen<in TBase>
    {
        void When(TBase testBase);
    }
}