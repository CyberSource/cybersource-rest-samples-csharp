using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class PurchaseAndRefund
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string organizationId = "uday_wf";
            const string startTime = "2018-05-01T12:00:00-05:00";
            const string endTime = "2018-05-30T12:00:00-05:00";
            const string paymentSubtype = "VI";
            const string viewBy = "requestDate";
            const string groupName = "groupName";
            const string offset = "20";
            const string limit = "2000";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/reporting/v3/purchase-refund-details?organizationId={organizationId}" +
                                $"&startTime={startTime}&endTime={endTime}" +
                                $"&groupName={groupName}&paymentSubtype={paymentSubtype}&viewBy={viewBy}&offset={offset}&limit={limit}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new PurchaseAndRefundDetailsApi(configurationSwagger);
                //var result = apiInstance.GetPurchaseAndRefundDetails(startTime, endTime, organizationId, paymentSubtype,
                //    viewBy, groupName, offset, limit);

                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}