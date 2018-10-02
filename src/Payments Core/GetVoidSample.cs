using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.Payments_Core
{
    public class GetVoidSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/pts/v2/voids/5335528892726038303523"
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new VoidApi(configurationSwagger);
                var result = apiInstance.GetVoid("5335528892726038303523");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
