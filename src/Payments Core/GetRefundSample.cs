using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.Payments_Core
{
    public class GetRefundSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/pts/v2/refunds/5335504389516958903526"
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new RefundApi(configurationSwagger);
                var result = apiInstance.GetRefund("5335504389516958903526");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
