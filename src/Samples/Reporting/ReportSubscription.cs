using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class ReportSubscription
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string reportId = "TRRReport";
            const string organizationId = "testrest";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v2/reports/{reportId}?organizationId={organizationId}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportsApi(configurationSwagger);
                //var result = apiInstance.GetReportByReportId(reportId, organizationId);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
