using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments_Core
{
    public class VoidCaptureSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_void");
            var requestBody = new VoidCaptureRequest(clientReferenceInformationObj);

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/captures/5335461889256917903529/voids",
                RequestJsonData = JsonConvert.SerializeObject(requestBody)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new VoidApi(configurationSwagger);
                var result = apiInstance.VoidCapture(requestBody, "5335461889256917903529");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
