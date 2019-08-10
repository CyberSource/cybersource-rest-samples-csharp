
namespace RoadRunner
{
    public class TestData
    {
        public string testCaseName;
        public AssertionData[] assertions;

        public TestData(string testCaseName, AssertionData[] assertions)
        {
            this.testCaseName = testCaseName;
            this.assertions = assertions;
        }
    }

}
