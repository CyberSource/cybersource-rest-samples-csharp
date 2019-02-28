using System;
using System.Globalization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class RetrieveAvailableReports
    {
        public static void Run()
        {
            try
            {
                var startTime = DateTime.ParseExact("2018-10-01T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                var endTime = DateTime.ParseExact("2018-10-30T23:59:59Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                var timeQueryType = "executedTime";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportsApi(clientConfig);

                var result = apiInstance.SearchReports(startTime, endTime, timeQueryType, organizationId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
