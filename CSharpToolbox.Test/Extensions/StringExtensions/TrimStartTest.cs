using System;
using CSharpToolbox.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Extensions.StringExtensions
{
    [TestClass]
    public class TrimStartTest : TrimTestBase
    {
        protected override Action TheStringIsTrimmedBy(string text)
        {
            return () => Result = Text.TrimStart(text);
        }

        public override bool TrimStart => true;
        public override bool TrimEnd => false;
    }
}