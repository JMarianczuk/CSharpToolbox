using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.ControlFlow.Flag
{
    using Flag = CSharpToolbox.ControlFlow.Flag;

    [TestClass]
    public class FlagTests
    {
        private Flag Flag { get; set; }
        private bool FlagValue => Flag;

        [TestMethod]
        public void AssignmentTest()
        {
            Flag = false;
            FlagValue.Should().BeFalse();

            Flag = true;
            FlagValue.Should().BeTrue();
        }

        [TestMethod]
        public void InitialFalseTest()
        {
            Flag = false;
            using (Flag.Toggle())
            {
                FlagValue.Should().BeTrue();
            }
            FlagValue.Should().BeFalse();
        }

        [TestMethod]
        public void InitialTrueTest()
        {
            Flag = true;
            using (Flag.Toggle())
            {
                FlagValue.Should().BeFalse();
            }
            FlagValue.Should().BeTrue();
        }
    }
}