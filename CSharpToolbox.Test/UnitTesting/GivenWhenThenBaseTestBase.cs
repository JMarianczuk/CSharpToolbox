using System.Collections.Generic;

namespace CSharpToolbox.Test.UnitTesting
{
    public class GivenWhenThenBaseTestBase : GivenWhenThenBase<GivenWhenThenBaseTestBase, IEnumerable<int>>
    {
        public IEnumerable<int> Numbers { get; set; }

        protected void Given<TGiven>(params int[] numbers)
            where TGiven : IGiven<GivenWhenThenBaseTestBase, IEnumerable<int>>, new()
        {
            base.Given<TGiven>(numbers);
        }
    }
}