using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class CreateSubscriptionReport
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string reportName = "subscriptionAutomation2";

            //var requestObj = new Request();

            //requestObj.ReportDefinitionName = "TransactionRequestClass";
            //var reportFieldsObj = new List<string>();
            //reportFieldsObj.Add("Request.RequestID");
            //reportFieldsObj.Add("Request.TransactionDate");
            //reportFieldsObj.Add("Request.MerchantID");

            //requestObj.ReportFields = reportFieldsObj;

            //requestObj.ReportMimeType = "application/xml";
            //requestObj.ReportFrequency = "DAILY";
            //requestObj.Timezone = "America/Chicago";
            //requestObj.StartTime = "0900";
            //requestObj.StartDay = "1";
            //var reportFiltersObj = new ReportFilters();

            //requestObj.ReportFilters = reportFiltersObj;

            //var reportPreferencesObj = new ReportPreferences();

            //reportPreferencesObj.SignedAmounts = "False";
            //requestObj.ReportPreferences = reportPreferencesObj;

            //requestObj.OrganizationId = "uday_wf";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "PUT",
                RequestTarget = $"/reporting/v3/report-subscriptions/{reportName}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new ReportSubscriptionsApi(configurationSwagger);
                //var result = apiInstance.CreateSubscription(reportName, requestBody);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}