using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.Payments_Core
{
    public class GetCreditSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/pts/v2/credits/5332036920866055004101"
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new CreditApi(configurationSwagger);
                var result = apiInstance.GetCredit("5332036920866055004101");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
