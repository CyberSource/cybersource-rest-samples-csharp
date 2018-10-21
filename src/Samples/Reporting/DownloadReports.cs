using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DownloadReports
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string organizationId = "organizationId";
            const string reportName = "ubc_sso_1";
            const string reportDate = "2018-08-10";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/report-downloads?organizationId={organizationId}&reportName={reportName}&reportDate={reportDate}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportDownloadsApi(configurationSwagger);
                //var result = apiInstance.DownloadReport(reportDate, reportName, organizationId);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}