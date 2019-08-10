namespace RoadRunner
{
    public class AssertionData
    {
        public dynamic expectedValue;
        public dynamic actualValue;
        public string message;

        public AssertionData(dynamic expectedValue, dynamic actualValue, string message)
        {
            this.expectedValue = expectedValue;
            this.actualValue = actualValue;
            this.message = message;
        }
    }
}