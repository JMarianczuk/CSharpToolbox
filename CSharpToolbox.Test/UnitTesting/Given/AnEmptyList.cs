using System.Linq;

namespace CSharpToolbox.Test.UnitTesting.Given
{
    public class AnEmptyList : IGiven<GivenWhenThenBaseTestBase>
    {
        public void Given(GivenWhenThenBaseTestBase testBase)
        {
            testBase.Numbers = Enumerable.Empty<int>();
        }
    }
}