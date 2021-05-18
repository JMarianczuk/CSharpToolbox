using System;
using CSharpToolbox.ControlFlow;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.ControlFlow.SwitchStatement
{
    [TestClass]
    public class SwitchStatementNoResultTest : SwitchStatementTestBase<string, bool>
    {
        protected SwitchStatement<string> NoResultSwitch;
        protected override SwitchStatementBase<string, bool> Switch => NoResultSwitch;

        [TestInitialize]
        public void Init()
        {
            NoResultSwitch = null;
            Result = null;
        }

        protected void ASwitchStatement()
        {
            NoResultSwitch = new SwitchStatement<string>();
        }

        protected Action ASwitchSection(string value, Action action = null)
        {
            return () => NoResultSwitch.Add(value, action);
        }

        protected Action ADefaultSection(Action action = null)
        {
            return () => NoResultSwitch.Default = new SwitchStatement<string>.DefaultSection { Action = action };
        }

        [TestMethod]
        public void SwitchNoSectionNotMatched()
        {
            Given(ASwitchStatement);
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheValueWasNotMatched);
        }
        [TestMethod]
        public void SwitchSingleSectionMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"));
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheValueWasMatched);
        }

        [TestMethod]
        public void SwitchSingleSectionNotMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"));
            When(TheSwitchIsEvaluatedWith("def"));
            Then(TheValueWasNotMatched);
        }

        [TestMethod]
        public void SwitchMultipleSectionsMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"))
                .And(ASwitchSection("def"));

            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheValueWasMatched);

            When(TheSwitchIsEvaluatedWith("def"));
            Then(TheValueWasMatched);
        }

        [TestMethod]
        public void SwitchMultipleSectionsNotMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"))
                .And(ASwitchSection("def"));
            When(TheSwitchIsEvaluatedWith("ghi"));
            Then(TheValueWasNotMatched);
        }

        [TestMethod]
        public void SwitchSingleSectionAction()
        {
            bool called = false;
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", action: () => called = true));
            When(TheSwitchIsEvaluatedWith("abc"));
            called.Should().BeTrue();
        }

        [TestMethod]
        public void SwitchMultipleSectionAction()
        {
            bool firstCalled = false;
            bool secondCalled = false;
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", action: () => firstCalled = true))
                .And(ASwitchSection("def", action: () => secondCalled = true));

            When(TheSwitchIsEvaluatedWith("abc"));
            firstCalled.Should().BeTrue();
            secondCalled.Should().BeFalse();

            firstCalled = false;
            secondCalled = false;
            When(TheSwitchIsEvaluatedWith("def"));
            firstCalled.Should().BeFalse();
            secondCalled.Should().BeTrue();
        }

        [TestMethod]
        public void SwitchNullValueMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection(null));
            When(TheSwitchIsEvaluatedWith(null));
            Then(TheValueWasMatched);
        }

        [TestMethod]
        public void SwitchNullValueNotMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"));
            When(TheSwitchIsEvaluatedWith(null));
            Then(TheValueWasNotMatched);
        }

        [TestMethod]
        public void SwitchOnlyDefaultSectionMatched()
        {
            Given(ASwitchStatement)
                .And(ADefaultSection());
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheValueWasMatched);
        }


        [TestMethod]
        public void SwitchSingleSectionAndDefault_SectionMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"))
                .And(ADefaultSection());
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheValueWasMatched);
        }


        [TestMethod]
        public void SwitchSingleSectionAndDefault_DefaultMatched()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc"))
                .And(ADefaultSection());
            When(TheSwitchIsEvaluatedWith("def"));
            Then(TheValueWasMatched);
        }
    }
}