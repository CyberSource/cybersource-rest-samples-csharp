using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.Payments_Core
{
    public class GetCaptureSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/pts/v2/captures/5332051835286063504108"
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new CaptureApi(configurationSwagger);
                var result = apiInstance.GetCapture("5332051835286063504108");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
