using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpToolbox.UnitTesting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stateless;

namespace CSharpToolbox.Test.UnitTesting
{
    [TestClass]
    public class GivenWhenThenTests : GivenWhenThen
    {
        private bool _executed;
        private readonly List<int> _numbers = new List<int>();

        [TestInitialize]
        public void Initialize()
        {
            _executed = false;
            _numbers.Clear();
        }

        private void Check()
        {
            _executed.Should().BeTrue();
            _executed = false;
        }

        private void CheckOrder()
        {
            _numbers.Should().BeInAscendingOrder();
            _numbers.Clear();
        }

        private const int Normal = 0;
        private const int Async = 1;
        private const int Count = 2;
        private const int CountAsync = 3;

        [TestMethod]
        public async Task GeneralExecutionTest()
        {
            bool executed = false;

            void Nothing()
            {
            }

            Task NothingAsync() => Task.CompletedTask;
            void Execute() => executed = true;

            Task ExecuteAsync()
            {
                executed = true;
                return Task.CompletedTask;
            }

            int[] choice = { Normal, Async };
            IEnumerable<IEnumerable<int>> options = choice.Select(x => new[] { x });

            ProgressOptions progressOptions = ops => Generator.GenerateOptions(ops, choice);
            ProgressSequence progressSequence = (gwts, option, _, isLast) =>
            {
                switch (option)
                {
                    case Normal:
                        gwts = isLast
                            ? gwts.SelectMany(x => Generator.GenerateCalls(x, Execute))
                            : gwts.SelectMany(x => Generator.GenerateCalls(x, Nothing));
                        break;
                    case Async:
                        gwts = isLast
                            ? gwts.SelectMany(x => Generator.GenerateCalls(x, ExecuteAsync))
                            : gwts.SelectMany(x => Generator.GenerateCalls(x, NothingAsync));
                        break;
                }
                return gwts;
            };
            ExecuteCheck executeCheck = async seq =>
            {
                executed = false;
                var cont = seq();
                if (cont is IAsyncContinuation asyncCont)
                {
                    await asyncCont;
                }
                executed.Should().BeTrue();
            };

            await Test(options, progressOptions, progressSequence, executeCheck);
        }

        [TestMethod]
        public async Task SequentialExecutionTest()
        {
            List<int> numbers = new List<int>();

            Action DoCount(int x) => () => numbers.Add(x);

            AsyncAction DoCountAsync(int x) => () =>
            {
                numbers.Add(x);
                return Task.CompletedTask;
            };

            var choice = new[] { Count, CountAsync };
            var options = choice.Select(x => new[] { x });
            ProgressOptions progressOptions = ops => Generator.GenerateOptions(ops, choice);
            ProgressSequence progressSequence = (gwts, option, i, _) =>
            {
                switch (option)
                {
                    case Count:
                        gwts = gwts.SelectMany(x => Generator.GenerateCalls(x, DoCount(i)));
                        break;
                    case CountAsync:
                        gwts = gwts.SelectMany(x => Generator.GenerateCalls(x, DoCountAsync(i)));
                        break;
                }
                return gwts;
            };
            ExecuteCheck executeCheck = async seq =>
            {
                numbers.Clear();
                var cont = seq();
                if (cont is IAsyncContinuation asyncCont)
                {
                    await asyncCont;
                }
                numbers.Should().BeInAscendingOrder();
            };
            await Test(options, progressOptions, progressSequence, executeCheck);
        }

        public async Task Test(IEnumerable<IEnumerable<int>> initialOptions, ProgressOptions progressOptions, ProgressSequence progressSequence, ExecuteCheck executeCheck)
        {
            var options = initialOptions;

            for (int level = 0; level < 7; level += 1)
            {
                var ops = options.Select(x => x.ToArray()).ToList();
                foreach (var option in ops)
                {
                    Func<GivenWhenThen> start = () => this;
                    await TestSequence(start, level, option, progressSequence, executeCheck);
                }
                options = progressOptions(ops);
            }
        }

        public delegate IEnumerable<Func<object>> ProgressSequence(IEnumerable<Func<object>> gwts, int option, int index, bool isLast);

        public delegate IEnumerable<IEnumerable<int>> ProgressOptions(IEnumerable<IEnumerable<int>> options);

        public delegate Task ExecuteCheck(Func<object> sequence);

        private async Task TestSequence(Func<GivenWhenThen> start, int level, int[] option, ProgressSequence progress, ExecuteCheck executeCheck)
        {
            IEnumerable<Func<object>> gwts = new Func<object>[] { start };
            for (int i = 0; i < level; i += 1)
            {
                gwts = progress(gwts, option[i], i, false);
            }
            gwts = progress(gwts, option[level], level, true);

            foreach (var e in gwts)
            {
                await executeCheck(e);
            }
        }
    }

    public static class Generator
    {
        public static IEnumerable<IEnumerable<int>> GenerateOptions(IEnumerable<IEnumerable<int>> o, IEnumerable<int> append)
        {
            return o.SelectMany(x => append.Select(x.Append));
        }

        public static IEnumerable<Func<object>> GenerateCalls(Func<object> f, Action a)
        {
            List<Func<object>> result = new List<Func<object>>();

            void Add<T>(Func<T> res) where T : class
            {
                result.Add(res);
            }

            switch (f)
            {
                case Func<GivenWhenThen> gwt:
                    Add(() => gwt().Given(a));
                    Add(() => gwt().When(a));
                    Add(() => gwt().Then(a));
                    break;
                case Func<IGivenContinuation> g:
                    Add(() => g().And(a));
                    Add(() => g().When(a));
                    Add(() => g().Then(a));
                    break;
                case Func<IGivenAsyncContinuation> ga:
                    Add(() => ga().And(a));
                    Add(() => ga().When(a));
                    Add(() => ga().Then(a));
                    break;
                case Func<IWhenContinuation> w:
                    Add(() => w().And(a));
                    Add(() => w().Then(a));
                    break;
                case Func<IWhenAsyncContinuation> wa:
                    Add(() => wa().And(a));
                    Add(() => wa().Then(a));
                    break;
                case Func<IThenContinuation> t:
                    Add(() => t().And(a));
                    break;
                case Func<IThenAsyncContinuation> ta:
                    Add(() => ta().And(a));
                    break;
                default:
                    throw new Exception("unsupported type");
            }
            return result;
        }

        public static IEnumerable<Func<object>> GenerateCalls(object obj, AsyncAction a)
        {
            List<Func<object>> result = new List<Func<object>>();

            void Add<T>(Func<T> f) where T : class
            {
                result.Add(f);
            }

            switch (obj)
            {
                case Func<GivenWhenThen> gwt:
                    Add(() => gwt().Given(a));
                    Add(() => gwt().When(a));
                    Add(() => gwt().Then(a));
                    break;
                case Func<IGivenContinuation> g:
                    Add(() => g().And(a));
                    Add(() => g().When(a));
                    Add(() => g().Then(a));
                    break;
                case Func<IGivenAsyncContinuation> ga:
                    Add(() => ga().And(a));
                    Add(() => ga().When(a));
                    Add(() => ga().Then(a));
                    break;
                case Func<IWhenContinuation> w:
                    Add(() => w().And(a));
                    Add(() => w().Then(a));
                    break;
                case Func<IWhenAsyncContinuation> wa:
                    Add(() => wa().And(a));
                    Add(() => wa().Then(a));
                    break;
                case Func<IThenContinuation> t:
                    Add(() => t().And(a));
                    break;
                case Func<IThenAsyncContinuation> ta:
                    Add(() => ta().And(a));
                    break;
                default:
                    throw new Exception("unsupported type");
            }
            return result;
        }
    }
}