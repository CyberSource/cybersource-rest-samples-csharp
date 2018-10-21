using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetReportByReportID
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string reportId = "7557b133-8db3-a172-e053-7cb8d30a0b7e";
            const string organizationId = "uday_wf";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/reports/{reportId}?organizationId={organizationId}"
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