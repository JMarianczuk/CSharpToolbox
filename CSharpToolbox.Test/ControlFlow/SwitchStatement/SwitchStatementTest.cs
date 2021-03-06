﻿using System;
using CSharpToolbox.ControlFlow;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.ControlFlow.SwitchStatement
{
    using DefaultSection = SwitchStatement<string, int>.DefaultSection;
    [TestClass]
    public class SwitchStatementTest : SwitchStatementTestBase<string, int>
    {
        protected SwitchStatement<string, int> WithResultSwitch;
        protected override SwitchStatementBase<string, int> Switch => WithResultSwitch;

        [TestInitialize]
        public void Init()
        {
            WithResultSwitch = null;
            Result = null;
        }

        protected void ASwitchStatement()
        {
            WithResultSwitch = new SwitchStatement<string, int>();
        }

        protected Action ASwitchSection(string value, Action action = null, int result = 0)
        {
            return () => WithResultSwitch.Add(value, action, result);
        }

        protected Action ADefaultSection(Action action = null, int result = 0)
        {
            return () => WithResultSwitch.Default = new DefaultSection { Action = action, Result = result };
        }

        protected Action TheResultIs(int result)
        {
            return () => Result.Result.Should().Be(result);
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
        public void SwitchSingleSectionResult()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", result: 1));
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheResultIs(1));
        }

        [TestMethod]
        public void SwitchMultipleSectionsResult()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", result: 1))
                .And(ASwitchSection("def", result: 2));

            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheResultIs(1));

            When(TheSwitchIsEvaluatedWith("def"));
            Then(TheResultIs(2));
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
        public void SwitchDefaultAction()
        {
            bool called = false;
            Given(ASwitchStatement)
                .And(ADefaultSection(action: () => called = true));
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
        public void SwitchOnlyDefaultSectionReturn()
        {
            Given(ASwitchStatement)
                .And(ADefaultSection(result: 4));
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheResultIs(4));
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

        [TestMethod]
        public void SwitchSingleSectionAndDefault_SectionReturn()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", result: 1))
                .And(ADefaultSection(result: 3));
            When(TheSwitchIsEvaluatedWith("abc"));
            Then(TheResultIs(1));
        }
        [TestMethod]
        public void SwitchSingleSectionAndDefault_DefaultReturn()
        {
            Given(ASwitchStatement)
                .And(ASwitchSection("abc", result: 1))
                .And(ADefaultSection(result: 3));
            When(TheSwitchIsEvaluatedWith("def"));
            Then(TheResultIs(3));
        }
    }
}