using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DeleteSubscriptionsReport
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string reportName = "subscriptionAutomation2";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "DELETE",
                RequestTarget = $"/reporting/v3/report-subscriptions/{reportName}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportSubscriptionsApi(configurationSwagger);
                //var result = apiInstance.DeleteSubscription(reportName);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
