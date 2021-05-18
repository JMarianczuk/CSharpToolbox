using System;
using CSharpToolbox.UnitTesting;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    public abstract class StringExtensionsTestBase : GivenWhenThen
    {
        protected string Text;

        protected void AnEmptyString()
        {
            Text = string.Empty;
        }

        protected Action AString(string text)
        {
            return () => Text = text;
        }
    }
}