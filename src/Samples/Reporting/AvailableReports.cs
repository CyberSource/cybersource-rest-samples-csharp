using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class AvailableReports
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string startTime = "2018-05-01T12:00:00-05:00";
            const string endTime = "2018-05-30T12:00:00-05:00";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/notification-of-changes?startTime={startTime}&endTime={endTime}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new NotificationOfChangesApi(configurationSwagger);
                //var result = apiInstance.GetNotificationOfChangeReport(startTime, endTime);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}