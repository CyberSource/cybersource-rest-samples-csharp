using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.Payments_Core
{
    public class GetReversalSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/pts/v2/reversals/5335484687096937303524"
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new ReversalApi(configurationSwagger);
                var result = apiInstance.GetAuthReversal("5335484687096937303524");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
