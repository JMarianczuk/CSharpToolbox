using CSharpToolbox.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.InitializableCollection
{
    [TestClass]
    public class OneParameter : InitializableCollectionTestBase
    {
        protected override void AnInitializableCollection()
        {
            Initializable = new InitializableCollection<int>();
        }
    }
}