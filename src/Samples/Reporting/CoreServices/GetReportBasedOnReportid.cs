using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetReportBasedOnReportid
    {
        public static void Run()
        {
            const string reportId = "79642c43-2368-0cd5-e053-a2588e0a7b3c";
            const string organizationId = "testrest";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportsApi(clientConfig);

                var result = apiInstance.GetReportByReportId(reportId, organizationId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
