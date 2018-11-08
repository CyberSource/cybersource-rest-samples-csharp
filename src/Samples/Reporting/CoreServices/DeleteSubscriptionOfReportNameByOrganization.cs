using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class DeleteSubscriptionOfReportNameByOrganization
    {
        public static string ReportNameToDelete { get; set; }

        public static void Run()
        {
            if (string.IsNullOrEmpty(ReportNameToDelete))
            {
                ReportNameToDelete = "testrest_subcription_v1";
            }

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportSubscriptionsApi(clientConfig);

                var result = apiInstance.DeleteSubscriptionWithHttpInfo(ReportNameToDelete);
                Console.WriteLine(result);
                ReportNameToDelete = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}