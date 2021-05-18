using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpToolbox.UnitTesting
{
    public delegate Task AsyncAction();
    public abstract class GivenWhenThen
    {
        public IGivenContinuation Given(Action given)
        {
            given();
            return new GivenContinuation();
        }
        public IWhenContinuation When(Action when)
        {
            when();
            return new WhenContinuation();
        }

        public IThenContinuation Then(Action then)
        {
            then();
            return new ThenContinuation();
        }

        public IGivenAsyncContinuation Given(AsyncAction given) => new GivenAsyncContinuation(given());
        public IWhenAsyncContinuation When(AsyncAction when) => new WhenAsyncContinuation(when());
        public IThenAsyncContinuation Then(AsyncAction then) => new ThenAsyncContinuation(then());

        private class GivenContinuation : IGivenContinuation
        {
            public IGivenContinuation And(Action given)
            {
                given();
                return this;
            }

            public IWhenContinuation When(Action when)
            {
                when();
                return new WhenContinuation();
            }

            public IThenContinuation Then(Action then)
            {
                then();
                return new ThenContinuation();
            }

            public IGivenAsyncContinuation And(AsyncAction given) => new GivenAsyncContinuation(given());
            public IWhenAsyncContinuation When(AsyncAction when) => new WhenAsyncContinuation(when());
            public IThenAsyncContinuation Then(AsyncAction then) => new ThenAsyncContinuation(then());
        }

        private class WhenContinuation : IWhenContinuation
        {
            public IWhenContinuation And(Action when)
            {
                when();
                return this;
            }

            public IThenContinuation Then(Action then)
            {
                then();
                return new ThenContinuation();
            }

            public IWhenAsyncContinuation And(AsyncAction when) => new WhenAsyncContinuation(when());
            public IThenAsyncContinuation Then(AsyncAction then) => new ThenAsyncContinuation(then());
        }

        private class ThenContinuation : IThenContinuation
        {
            public IThenContinuation And(Action then)
            {
                then();
                return this;
            }
            public IThenAsyncContinuation And(AsyncAction then) => new ThenAsyncContinuation(then());
        }
        private abstract class AsyncContinuation : IAsyncContinuation
        {
            private readonly Task _task;
            protected AsyncContinuation(Task task)
            {
                _task = task;
            }
            protected async Task ExecuteInOrder(AsyncAction action)
            {
                await _task;
                await action();
            }
            protected async Task ExecuteInOrder(Action action)
            {
                await _task;
                action();
            }
            public TaskAwaiter GetAwaiter() => _task.GetAwaiter();
        }
        private class GivenAsyncContinuation : AsyncContinuation, IGivenAsyncContinuation
        {
            public GivenAsyncContinuation(Task givenTask) : base(givenTask) { }

            public IGivenAsyncContinuation And(AsyncAction given) => new GivenAsyncContinuation(ExecuteInOrder(given));
            public IWhenAsyncContinuation When(AsyncAction when) => new WhenAsyncContinuation(ExecuteInOrder(when));
            public IThenAsyncContinuation Then(AsyncAction then) => new ThenAsyncContinuation(ExecuteInOrder(then));

            public IGivenAsyncContinuation And(Action given) => new GivenAsyncContinuation(ExecuteInOrder(given));
            public IWhenAsyncContinuation When(Action when) => new WhenAsyncContinuation(ExecuteInOrder(when));
            public IThenAsyncContinuation Then(Action then) => new ThenAsyncContinuation(ExecuteInOrder(then));
        }

        private class WhenAsyncContinuation : AsyncContinuation, IWhenAsyncContinuation
        {
            public WhenAsyncContinuation(Task whenTask) : base(whenTask) { }

            public IWhenAsyncContinuation And(AsyncAction when) => new WhenAsyncContinuation(ExecuteInOrder(when));
            public IThenAsyncContinuation Then(AsyncAction then) => new ThenAsyncContinuation(ExecuteInOrder(then));

            public IWhenAsyncContinuation And(Action when) => new WhenAsyncContinuation(ExecuteInOrder(when));
            public IThenAsyncContinuation Then(Action then) => new ThenAsyncContinuation(ExecuteInOrder(then));
        }

        private class ThenAsyncContinuation : AsyncContinuation, IThenAsyncContinuation
        {
            public ThenAsyncContinuation(Task thenTask) : base(thenTask) { }

            public IThenAsyncContinuation And(AsyncAction then) => new ThenAsyncContinuation(ExecuteInOrder(then));

            public IThenAsyncContinuation And(Action then) => new ThenAsyncContinuation(ExecuteInOrder(then));
        }
    }

    public interface IGivenContinuation
    {
        IGivenContinuation And(Action given);
        IWhenContinuation When(Action when);
        IThenContinuation Then(Action then);

        IGivenAsyncContinuation And(AsyncAction given);
        IWhenAsyncContinuation When(AsyncAction when);
        IThenAsyncContinuation Then(AsyncAction then);
    }
    public interface IWhenContinuation
    {
        IWhenContinuation And(Action when);
        IThenContinuation Then(Action then);

        IWhenAsyncContinuation And(AsyncAction when);
        IThenAsyncContinuation Then(AsyncAction then);
    }

    public interface IThenContinuation
    {
        IThenContinuation And(Action then);

        IThenAsyncContinuation And(AsyncAction then);
    }

    public interface IAsyncContinuation
    {
        TaskAwaiter GetAwaiter();
    }
    public interface IGivenAsyncContinuation : IAsyncContinuation
    {
        IGivenAsyncContinuation And(AsyncAction given);
        IWhenAsyncContinuation When(AsyncAction when);
        IThenAsyncContinuation Then(AsyncAction then);

        IGivenAsyncContinuation And(Action given);
        IWhenAsyncContinuation When(Action when);
        IThenAsyncContinuation Then(Action then);
    }

    public interface IWhenAsyncContinuation : IAsyncContinuation
    {
        IWhenAsyncContinuation And(AsyncAction when);
        IThenAsyncContinuation Then(AsyncAction then);

        IWhenAsyncContinuation And(Action when);
        IThenAsyncContinuation Then(Action then);
    }
    public interface IThenAsyncContinuation : IAsyncContinuation
    {
        IThenAsyncContinuation And(AsyncAction then);

        IThenAsyncContinuation And(Action then);
    }
}