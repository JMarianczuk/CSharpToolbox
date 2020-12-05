using System;
using System.Threading;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.CancellationTokenExtensions
{
    [TestClass]
    public class CombinationTests : CancellationTokenExtensionsTestBase
    {
        private CancellationTokenSource _secondSource;

        private Action TheTokenIsCombinedWith(params CancellationToken[] tokens)
        {
            return () => Token.CombineWith(tokens);
        }

        private void ASecondTokenSource()
        {
            _secondSource = new CancellationTokenSource();
        }

        private void TheSecondSourceIsCancelled()
        {
            _secondSource.Cancel();
        }

        private void TheTokensAreCombined()
        {
            Token = Token.CombineWith(_secondSource.Token);
        }

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            _secondSource?.Cancel();
            _secondSource?.Dispose();
            _secondSource = null;
        }

        [TestMethod]
        public void NoCombinationTest_NoSourceCancel()
        {
            Given(ATokenSource);
            When(TheTokenIsCombinedWith(new CancellationToken[] { }));
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void NoCombinationTest_WithSourceCancel()
        {
            Given(ATokenSource);
            When(TheTokenIsCombinedWith(new CancellationToken[] { }), TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_NoSourceCancel()
        {
            Given(ATokenSource, ASecondTokenSource);
            When(TheTokensAreCombined);
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void CombinationTest_FirstSourceCancel()
        {
            Given(ATokenSource, ASecondTokenSource);
            When(TheTokensAreCombined, TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_SecondSourceCancel()
        {
            Given(ATokenSource, ASecondTokenSource);
            When(TheTokensAreCombined, TheSecondSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }
    }
}