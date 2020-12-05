using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.CancellationTokenExtensions
{
    [TestClass]
    public class CancellationTokenExtensionsTestBase : GivenWhenThen
    {
        protected CancellationTokenSource Source;
        protected CancellationToken Token;

        protected void ATokenSource()
        {
            Source = new CancellationTokenSource();
            Token = Source.Token;
        }

        protected void TheSourceIsCancelled()
        {
            Source.Cancel();
        }

        protected void TheResultTokenIsCancelled()
        {
            Token.IsCancellationRequested.Should().BeTrue();
        }

        protected void TheResultTokenIsNotCancelled()
        {
            Token.IsCancellationRequested.Should().BeFalse();
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            Source?.Cancel();
            Source?.Dispose();
            Source = null;
        }

        [TestMethod]
        public void SetupTest_NoCancel()
        {
            Given(ATokenSource);
            Then(TheResultTokenIsNotCancelled);
        }

        [TestMethod]
        public void SetupTest_WithCancel()
        {
            Given(ATokenSource);
            When(TheSourceIsCancelled);
            Then(TheResultTokenIsCancelled);
        }
    }
}