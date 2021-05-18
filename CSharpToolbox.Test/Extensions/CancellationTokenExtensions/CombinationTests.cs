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
            When(TheTokenIsCombinedWith(NoTokens));
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void NoCombinationTest_WithSourceCancelBefore()
        {
            Given(ATokenSource);
            When(TheSourceIsCancelled)
                .And(TheTokenIsCombinedWith(NoTokens));
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void NoCombinationTest_WithSourceCancelAfter()
        {
            Given(ATokenSource);
            When(TheTokenIsCombinedWith(NoTokens)).And(TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_NoSourceCancel()
        {
            Given(ATokenSource)
                .And(ASecondTokenSource);
            When(TheTokensAreCombined);
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void CombinationTest_FirstSourceCancelBefore()
        {
            Given(ATokenSource)
                .And(ASecondTokenSource);
            When(TheSourceIsCancelled)
                .And(TheTokensAreCombined);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_FirstSourceCancelAfter()
        {
            Given(ATokenSource)
                .And(ASecondTokenSource);
            When(TheTokensAreCombined)
                .And(TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_SecondSourceCancelBefore()
        {
            Given(ATokenSource)
                .And(ASecondTokenSource);
            When(TheSecondSourceIsCancelled)
                .And(TheTokensAreCombined);
            Then(TheResultTokenIsCancelled);
        }

        [TestMethod]
        public void CombinationTest_SecondSourceCancelAfter()
        {
            Given(ATokenSource)
                .And(ASecondTokenSource);
            When(TheTokensAreCombined)
                .And(TheSecondSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }
    }
}