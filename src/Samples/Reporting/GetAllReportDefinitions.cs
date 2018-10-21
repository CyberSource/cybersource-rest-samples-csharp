using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetAllReportDefinitions
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string organizationId = "uday_wf";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/report-definitions?organizationId={organizationId}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportDefinitionsApi(configurationSwagger);
                //var result = apiInstance.GetResourceV2Info(organizationId);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}