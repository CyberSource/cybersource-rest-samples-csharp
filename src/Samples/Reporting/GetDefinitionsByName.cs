using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetDefinitionsByName
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string reportDefinitionName = "SubscriptionDetailClass";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/report-definitions/{reportDefinitionName}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportDefinitionsApi(configurationSwagger);
                //var result = apiInstance.GetResourceInfoByReportDefinition(reportDefinitionName);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}