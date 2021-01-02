using System;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    [TestClass]
    public class TrimEndTest : TrimTestBase
    {
        protected override Action TheStringIsTrimmedBy(string text)
        {
            return () => Result = Text.TrimEnd(text);
        }

        public override bool TrimStart => false;
        public override bool TrimEnd => true;
    }
}