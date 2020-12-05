using System;
using System.Threading.Tasks;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.CancellationTokenExtensions
{
    [TestClass]
    public class WithTimeoutTests : CancellationTokenExtensionsTestBase
    {
        private Action ATimeoutIsAdded(TimeSpan timeout)
        {
            return () => Token = Token.AddTimeout(timeout);
        }

        [TestMethod]
        public void LongTimeoutTest_NoSourceCancel()
        {
            Given(ATokenSource);
            When(ATimeoutIsAdded(TimeSpan.FromMinutes(1)));
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void LongTimeoutTest_WithSourceCancel()
        {
            Given(ATokenSource);
            When(ATimeoutIsAdded(TimeSpan.FromMinutes(1)), TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public async Task ShortTimeoutTest_NoSourceCancel()
        {
            Given(ATokenSource);
            When(ATimeoutIsAdded(TimeSpan.FromMilliseconds(1)));
            await Task.Delay(TimeSpan.FromMilliseconds(20));
            Then(TheResultTokenIsCancelled);
        }
    }
}