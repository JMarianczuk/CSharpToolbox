using System.Collections.Generic;

namespace CSharpToolbox.Test.UnitTesting.Given
{
    public class Numbers : IGiven<GivenWhenThenBaseTestBase, IEnumerable<int>>
    {
        public void Given(GivenWhenThenBaseTestBase testBase, IEnumerable<int> numbers)
        {
            testBase.Numbers = numbers;
        }
    }
}