using FluentAssertions;

namespace CSharpToolbox.Test.Extensions.IEnumerableExtensions
{
    public abstract class BoolResultType : IEnumerableExtensionsTestBase
    {
        protected bool Result;

        protected void TheResultIsTrue()
        {
            Result.Should().BeTrue();
        }

        protected void TheResultIsFalse()
        {
            Result.Should().BeFalse();
        }
    }
}