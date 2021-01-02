using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CSharpToolbox.Test.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test
{
    public class ExtendedTestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var ignoreAttribute = GetMethodAndClassHierarchyAttributes<IgnoreIfAttribute>(testMethod)
                .FirstOrDefault(ig => ig.ShouldIgnore(testMethod));
            if (ignoreAttribute != null)
            {
                var message =
                    $"Test not executed. Conditional method '{ignoreAttribute.IgnoreCriteriaMethodName}' evaluated to 'true', indicating ignore";
                return new[]
                {
                    new TestResult
                    {
                        Outcome = UnitTestOutcome.Inconclusive,
                        TestFailureException = new AssertInconclusiveException(message),
                    }
                };
            }
            var executeAttributes = GetMethodAndClassHierarchyAttributes<ExecuteIfAttribute>(testMethod).ToList();
            if (executeAttributes.Any() && !executeAttributes.Any(e => e.ShouldExecute(testMethod)))
            {
                var message =
                    $"Test not executed. None of the stated conditional methods indicating execution returned 'true'.";
                return new[]
                {
                    new TestResult
                    {
                        Outcome = UnitTestOutcome.Inconclusive,
                        TestFailureException = new AssertInconclusiveException(message),
                    }
                };
            }
            return base.Execute(testMethod);
        }

        private static IEnumerable<TAttribute> GetMethodAndClassHierarchyAttributes<TAttribute>(ITestMethod testMethod) where TAttribute : Attribute
        {
            var methodAttributes = testMethod.GetAttributes<TAttribute>(true).ToList();

            var classAttributes = new List<TAttribute>();
            var type = testMethod.MethodInfo.DeclaringType;
            while (type != null)
            {
                classAttributes.AddRange(type.GetCustomAttributes<TAttribute>(true));
                type = type.DeclaringType;
            }

            return methodAttributes.Concat(classAttributes);
        }

        public static bool EvaluatePropertyOrMethod(ITestMethod testMethod, string name)
        {
            var declaringType = testMethod.MethodInfo.DeclaringType;
            var actualType = declaringType.Assembly.GetTypes()
                .FirstOrDefault(t => t.FullName == testMethod.TestClassName) ?? declaringType;
            try
            {
                const BindingFlags searchFlags =
                    BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.FlattenHierarchy
                    | BindingFlags.Static;
                var members = actualType.GetMember(name);
                var property = members.FirstOrDefault(m => m.MemberType == MemberTypes.Property);
                if (property != null)
                {
                    var prop = declaringType
                        .GetProperty(name);
                    return (bool) prop.GetMethod
                        .Invoke(Activator.CreateInstance(actualType), new object[] { });
                }
                var method = declaringType.GetMethod(name, searchFlags);
                return (bool) method.Invoke(null, null);
            }
            catch (Exception e)
            {
                var message = $"Member {name} not found. Ensure the method is in the same class as the test method, returns a `bool`, and doesn't accept any parameters. Exception: {e.Message}";
                throw new ArgumentException(message, e);
            }
        }
    }
}