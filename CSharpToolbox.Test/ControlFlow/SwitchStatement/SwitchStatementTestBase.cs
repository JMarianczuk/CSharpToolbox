using System;
using CSharpToolbox.ControlFlow;
using FluentAssertions;

namespace CSharpToolbox.Test.ControlFlow.SwitchStatement
{
    public abstract class SwitchStatementTestBase<TMatch, TResult> : GivenWhenThen where TMatch : IEquatable<TMatch>
    {
        protected abstract SwitchStatementBase<TMatch, TResult> Switch { get; }
        protected SwitchStatement<TMatch, TResult>.SwitchResult Result;

        protected Action TheSwitchIsEvaluatedWith(TMatch expression)
        {
            return () => Result = Switch.Execute(expression);
        }

        protected void TheValueWasMatched()
        {
            Result.Matched.Should().BeTrue();
        }

        protected void TheValueWasNotMatched()
        {
            Result.Matched.Should().BeFalse();
        }
    }
}