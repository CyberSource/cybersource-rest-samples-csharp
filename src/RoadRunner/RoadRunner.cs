using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoadRunner
{
    [TestClass]
    public class RoadRunner
    {
        [DataTestMethod]
        [CustomDataSource]
        public void TestRunner(TestData data)
        {
            foreach (AssertionData d in data.assertions)
            {
                Assert.AreEqual(d.expectedValue, d.actualValue, d.message);
            }
        }
    }
}
