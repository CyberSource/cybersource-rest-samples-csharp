using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class RetrieveAvailableReports
    {
        public static void Run()
        {
            try
            {
                var startTime = "2018-10-01T00:00:00Z";
                var endTime = "2018-10-30T23:59:59Z";
                var timeQueryType = "executedTime";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportsApi(clientConfig);

                var result = apiInstance.SearchReports(startTime, endTime, timeQueryType, organizationId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
