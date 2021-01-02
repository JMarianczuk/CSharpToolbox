using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.UnitTesting
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExecuteIfAttribute : Attribute
    {
        public string ExecuteCriteriaMethodName { get; set; }
        public ExecuteIfAttribute(string executeCriteriaMethodName = "ExecuteIf")
        {
            ExecuteCriteriaMethodName = executeCriteriaMethodName;
        }

        public bool ShouldExecute(ITestMethod testMethod) =>
            ExtendedTestMethodAttribute.EvaluatePropertyOrMethod(testMethod, ExecuteCriteriaMethodName);
    }
}