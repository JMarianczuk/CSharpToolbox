using System;
using System.Collections.Generic;
using CSharpToolbox.ControlFlow;

namespace CSharpToolbox.Test.ControlFlow
{
    public class SyntaxTest
    {
        public void SyntaxTestWithResult()
        {
            var statement = new SwitchStatement<string, int>()
            {
                { "abc", () => Console.WriteLine("abc"), 5 }
            }.Execute("klm");
        }

        public void SyntaxTestWithoutResult()
        {
            var statement = new SwitchStatement<string>()
            {
                { "abc", () => { } },
                { "xyz", () => Console.Write("x=4") },
            }.Execute("klm");
        }

        public void SyntaxTestWithResultWithDefaultSection()
        {
            var statement = new SwitchStatement<string, int>()
            {
                Cases = 
                {
                    { "abc", () => {}, 2},
                },
                Default = { Action = () => {}, Result = 4 },
            };
        }

        public void SyntaxTestWithoutResultWithDefaultSection()
        {
            var statement = new SwitchStatement<string>()
            {
                Cases =
                {
                    { "abc", () => { } },
                },
                Default = { Action = () => { } }
            };
        }

        public void SyntaxTestMatchStatement()
        {
            var statement = new MapStatement<string, int>()
            {
                { "abc", 123 },
                { "def", 456 },
            };
        }

        public void SyntaxTestMatchWithDefault()
        {
            var statement = new MapStatement<string, int>()
            {
                Cases =
                {
                    { "abc", 123 },
                    { "def", 456 },
                },
                Default = { Result = 321 },
            };
        }
    }
}