using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.UnitTesting
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IgnoreIfAttribute : Attribute
    {
        public string IgnoreCriteriaMethodName { get; set; }

        public IgnoreIfAttribute(string ignoreCriteriaMethodName = "IgnoreIf")
        {
            IgnoreCriteriaMethodName = ignoreCriteriaMethodName;
        }

        public bool ShouldIgnore(ITestMethod testMethod) =>
            ExtendedTestMethodAttribute.EvaluatePropertyOrMethod(testMethod, IgnoreCriteriaMethodName);
    }
}