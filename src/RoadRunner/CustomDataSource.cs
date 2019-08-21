using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RoadRunner
{
    public class CustomDataSource : Attribute, ITestDataSource
    {
        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
            {
                TestData d = (TestData)data[0];
                return string.Format(CultureInfo.CurrentCulture, d.testCaseName);
            }
            return null;
        }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            string jsonContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "executor.json"));
            var roads = JObject.Parse(jsonContent);

            Assembly assembly = Assembly.LoadFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SampleCode.dll"));

            Dictionary<string, string> globalMap = new Dictionary<string, string>();

            AssertionData[] assertionDatas = new AssertionData[roads["Execution Order"].Count()];

            int i = 0;
            List<AssertionData> data = null;

            foreach (var road in roads["Execution Order"])
            {

                var uniqueName = road["uniqueName"].ToString();

                data = DataUtility.GetTestAssertionDataFromRoads(road, globalMap, uniqueName, assembly);

                if (data.Count > 0)
                {
                    // iterator to give unique test case name 
                    i += 1;

                    yield return new object[] { new TestData("Test_" + i + "_" + uniqueName, data.ToArray()) };
                }
            }
        }
    }
}
