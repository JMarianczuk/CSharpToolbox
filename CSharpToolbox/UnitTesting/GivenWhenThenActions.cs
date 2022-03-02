using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CSharpToolbox.UnitTesting
{
    public delegate Task AsyncAction();

    public delegate Task AsyncAction<TParameter>(in TParameter parameter);

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

        public IWhenContinuation<TResult> When<TResult>(Func<TResult> when)
        {
            return new WhenContinuation<TResult>(when());
        }

        public IThenContinuation Then(Action then)
        {
            then();
            return new ThenContinuation();
        }

        public IGivenAsyncContinuation Given(AsyncAction given)
        {
            return new GivenAsyncContinuation(given());
        }

        public IWhenAsyncContinuation When(AsyncAction when)
        {
            return new WhenAsyncContinuation(when());
        }

        public IWhenAsyncContinuation<TResult> When<TResult>(Func<Task<TResult>> when)
        {
            return new WhenAsyncContinuation<TResult>(when());
        }

        public IThenAsyncContinuation Then(AsyncAction then)
        {
            return new ThenAsyncContinuation(then());
        }

        private abstract class Continuation<TResult>
        {
            protected readonly TResult Result;

            protected Continuation(TResult result)
            {
                this.Result = result;
            }

            protected async Task<TResult> ExecuteInOrder(AsyncAction action)
            {
                await action();
                return this.Result;
            }

            protected async Task<TResult> ExecuteInOrder(AsyncAction<TResult> action)
            {
                await action(this.Result);
                return this.Result;
            }
        }

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

            public IGivenAsyncContinuation And(AsyncAction given)
            {
                return new GivenAsyncContinuation(given());
            }

            public IWhenAsyncContinuation When(AsyncAction when)
            {
                return new WhenAsyncContinuation(when());
            }

            public IThenAsyncContinuation Then(AsyncAction then)
            {
                return new ThenAsyncContinuation(then());
            }
        }

        private class WhenContinuation : IWhenContinuation
        {
            public IWhenContinuation And(Action when)
            {
                when();
                return this;
            }

            public IWhenContinuation<TResult> And<TResult>(Func<TResult> when)
            {
                return new WhenContinuation<TResult>(when());
            }

            public IThenContinuation Then(Action then)
            {
                then();
                return new ThenContinuation();
            }

            public IWhenAsyncContinuation And(AsyncAction when)
            {
                return new WhenAsyncContinuation(when());
            }

            public IWhenAsyncContinuation<TResult> And<TResult>(Func<Task<TResult>> when)
            {
                return new WhenAsyncContinuation<TResult>(when());
            }

            public IThenAsyncContinuation Then(AsyncAction then)
            {
                return new ThenAsyncContinuation(then());
            }
        }

        private class WhenContinuation<TResult> : Continuation<TResult>, IWhenContinuation<TResult>
        {
            public WhenContinuation(TResult result)
                : base(result)
            {
            }

            public IWhenContinuation<TOtherResult> And<TOtherResult>(Func<TResult, TOtherResult> when)
            {
                return new WhenContinuation<TOtherResult>(when(this.Result));
            }

            public IWhenContinuation<TResult> And(Action when)
            {
                when();
                return this;
            }

            public IThenContinuation<TResult> Then(Action<TResult> then)
            {
                then(this.Result);
                return new ThenContinuation<TResult>(this.Result);
            }

            public IThenContinuation<TResult> Then(Action then)
            {
                then();
                return new ThenContinuation<TResult>(this.Result);
            }

            public IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, Task<TOtherResult>> when)
            {
                return new WhenAsyncContinuation<TOtherResult>(when(this.Result));
            }

            public IWhenAsyncContinuation<TResult> And(AsyncAction when)
            {
                return new WhenAsyncContinuation<TResult>(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation<TResult> Then(AsyncAction<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> Then(AsyncAction then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }
        }

        private class ThenContinuation : IThenContinuation
        {
            public IThenContinuation And(Action then)
            {
                then();
                return this;
            }

            public IThenAsyncContinuation And(AsyncAction then)
            {
                return new ThenAsyncContinuation(then());
            }
        }

        private class ThenContinuation<TResult> : Continuation<TResult>, IThenContinuation<TResult>
        {
            public ThenContinuation(TResult result)
                : base(result)
            {
            }

            public IThenContinuation<TResult> And(Action<TResult> then)
            {
                then(this.Result);
                return this;
            }

            public IThenContinuation<TResult> And(Action then)
            {
                then();
                return this;
            }

            public IThenAsyncContinuation<TResult> And(AsyncAction<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> And(AsyncAction then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }
        }

        private abstract class AsyncContinuation : IAsyncContinuation
        {
            private readonly Task _task;

            protected AsyncContinuation(Task task)
            {
                this._task = task;
            }

            public TaskAwaiter GetAwaiter()
            {
                return this._task.GetAwaiter();
            }

            protected async Task ExecuteInOrder(AsyncAction action)
            {
                await this._task;
                await action();
            }

            protected async Task<TResult> ExecuteInOrder<TResult>(Func<Task<TResult>> func)
            {
                await this._task;
                return await func();
            }

            protected async Task ExecuteInOrder(Action action)
            {
                await this._task;
                action();
            }

            protected async Task<TResult> ExecuteInOrder<TResult>(Func<TResult> func)
            {
                await this._task;
                return func();
            }
        }

        private abstract class AsyncContinuation<TResult> : IAsyncContinuation<TResult>
        {
            private readonly Task<TResult> _task;

            protected AsyncContinuation(Task<TResult> task)
            {
                this._task = task;
            }

            public TaskAwaiter<TResult> GetAwaiter()
            {
                return this._task.GetAwaiter();
            }

            protected async Task<TOtherResult> ExecuteInOrder<TOtherResult>(Func<TResult, Task<TOtherResult>> func)
            {
                var res = await this._task;
                return await func(res);
            }

            protected async Task<TResult> ExecuteInOrder(AsyncAction action)
            {
                var res = await this._task;
                await action();
                return res;
            }

            protected async Task<TResult> ExecuteInOrder(AsyncAction<TResult> action)
            {
                var res = await this._task;
                await action(res);
                return res;
            }

            protected async Task<TOtherResult> ExecuteInOrder<TOtherResult>(Func<TResult, TOtherResult> func)
            {
                var res = await this._task;
                return func(res);
            }

            protected async Task<TResult> ExecuteInOrder(Action action)
            {
                var res = await this._task;
                action();
                return res;
            }

            protected async Task<TResult> ExecuteInOrder(Action<TResult> action)
            {
                var res = await this._task;
                action(res);
                return res;
            }
        }

        private class GivenAsyncContinuation : AsyncContinuation, IGivenAsyncContinuation
        {
            public GivenAsyncContinuation(Task givenTask)
                : base(givenTask)
            {
            }

            public IGivenAsyncContinuation And(AsyncAction given)
            {
                return new GivenAsyncContinuation(this.ExecuteInOrder(given));
            }

            public IWhenAsyncContinuation When(AsyncAction when)
            {
                return new WhenAsyncContinuation(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation Then(AsyncAction then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }

            public IGivenAsyncContinuation And(Action given)
            {
                return new GivenAsyncContinuation(this.ExecuteInOrder(given));
            }

            public IWhenAsyncContinuation When(Action when)
            {
                return new WhenAsyncContinuation(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation Then(Action then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }
        }

        private class WhenAsyncContinuation : AsyncContinuation, IWhenAsyncContinuation
        {
            public WhenAsyncContinuation(Task whenTask)
                : base(whenTask)
            {
            }

            public IWhenAsyncContinuation And(AsyncAction when)
            {
                return new WhenAsyncContinuation(this.ExecuteInOrder(when));
            }

            public IWhenAsyncContinuation<TResult> And<TResult>(Func<Task<TResult>> when)
            {
                return new WhenAsyncContinuation<TResult>(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation Then(AsyncAction then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }

            public IWhenAsyncContinuation And(Action when)
            {
                return new WhenAsyncContinuation(this.ExecuteInOrder(when));
            }

            public IWhenAsyncContinuation<TResult> And<TResult>(Func<TResult> when)
            {
                throw new NotImplementedException();
            }

            public IThenAsyncContinuation Then(Action then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }
        }

        private class WhenAsyncContinuation<TResult> : AsyncContinuation<TResult>, IWhenAsyncContinuation<TResult>
        {
            public WhenAsyncContinuation(Task<TResult> whenTask)
                : base(whenTask)
            {
            }

            public IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, Task<TOtherResult>> when)
            {
                return new WhenAsyncContinuation<TOtherResult>(this.ExecuteInOrder(when));
            }

            public IWhenAsyncContinuation<TResult> And(AsyncAction when)
            {
                return new WhenAsyncContinuation<TResult>(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation<TResult> Then(AsyncAction then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> Then<TOtherResult>(AsyncAction<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, TOtherResult> when)
            {
                return new WhenAsyncContinuation<TOtherResult>(this.ExecuteInOrder(when));
            }

            public IWhenAsyncContinuation<TResult> And(Action when)
            {
                return new WhenAsyncContinuation<TResult>(this.ExecuteInOrder(when));
            }

            public IThenAsyncContinuation<TResult> Then(Action then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> Then(Action<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }
        }

        private class ThenAsyncContinuation : AsyncContinuation, IThenAsyncContinuation
        {
            public ThenAsyncContinuation(Task thenTask)
                : base(thenTask)
            {
            }

            public IThenAsyncContinuation And(AsyncAction then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation And(Action then)
            {
                return new ThenAsyncContinuation(this.ExecuteInOrder(then));
            }
        }

        private class ThenAsyncContinuation<TResult> : AsyncContinuation<TResult>, IThenAsyncContinuation<TResult>
        {
            public ThenAsyncContinuation(Task<TResult> thenTask)
                : base(thenTask)
            {
            }

            public IThenAsyncContinuation<TResult> And(AsyncAction<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> And(AsyncAction then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> And(Action<TResult> then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }

            public IThenAsyncContinuation<TResult> And(Action then)
            {
                return new ThenAsyncContinuation<TResult>(this.ExecuteInOrder(then));
            }
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

        IWhenContinuation<TResult> And<TResult>(Func<TResult> when);

        IThenContinuation Then(Action then);

        IWhenAsyncContinuation And(AsyncAction when);

        IWhenAsyncContinuation<TResult> And<TResult>(Func<Task<TResult>> when);

        IThenAsyncContinuation Then(AsyncAction then);
    }

    public interface IWhenContinuation<TResult>
    {
        IWhenContinuation<TOtherResult> And<TOtherResult>(Func<TResult, TOtherResult> when);

        IWhenContinuation<TResult> And(Action when);

        IThenContinuation<TResult> Then(Action<TResult> then);

        IThenContinuation<TResult> Then(Action then);

        IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, Task<TOtherResult>> when);

        IWhenAsyncContinuation<TResult> And(AsyncAction when);

        IThenAsyncContinuation<TResult> Then(AsyncAction<TResult> then);

        IThenAsyncContinuation<TResult> Then(AsyncAction then);
    }

    public interface IThenContinuation
    {
        IThenContinuation And(Action then);

        IThenAsyncContinuation And(AsyncAction then);
    }

    public interface IThenContinuation<TResult>
    {
        IThenContinuation<TResult> And(Action<TResult> then);

        IThenContinuation<TResult> And(Action then);

        IThenAsyncContinuation<TResult> And(AsyncAction<TResult> then);

        IThenAsyncContinuation<TResult> And(AsyncAction then);
    }

    public interface IAsyncContinuation
    {
        TaskAwaiter GetAwaiter();
    }

    public interface IAsyncContinuation<TResult>
    {
        TaskAwaiter<TResult> GetAwaiter();
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

        IWhenAsyncContinuation<TResult> And<TResult>(Func<Task<TResult>> when);

        IThenAsyncContinuation Then(AsyncAction then);

        IWhenAsyncContinuation And(Action when);

        IWhenAsyncContinuation<TResult> And<TResult>(Func<TResult> when);

        IThenAsyncContinuation Then(Action then);
    }

    public interface IWhenAsyncContinuation<TResult> : IAsyncContinuation<TResult>
    {
        IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, Task<TOtherResult>> when);

        IWhenAsyncContinuation<TResult> And(AsyncAction when);

        IThenAsyncContinuation<TResult> Then(AsyncAction then);

        IThenAsyncContinuation<TResult> Then<TOtherResult>(AsyncAction<TResult> then);

        IWhenAsyncContinuation<TOtherResult> And<TOtherResult>(Func<TResult, TOtherResult> when);

        IWhenAsyncContinuation<TResult> And(Action when);

        IThenAsyncContinuation<TResult> Then(Action then);

        IThenAsyncContinuation<TResult> Then(Action<TResult> then);
    }

    public interface IThenAsyncContinuation : IAsyncContinuation
    {
        IThenAsyncContinuation And(AsyncAction then);

        IThenAsyncContinuation And(Action then);
    }

    public interface IThenAsyncContinuation<TResult> : IAsyncContinuation<TResult>
    {
        IThenAsyncContinuation<TResult> And(AsyncAction<TResult> then);

        IThenAsyncContinuation<TResult> And(AsyncAction then);

        IThenAsyncContinuation<TResult> And(Action<TResult> then);

        IThenAsyncContinuation<TResult> And(Action then);
    }
}