using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments_Core
{
    public class RefundCaptureSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation("Testing");
            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails("102.21", "USD");
            var orderInformationObj = new V2paymentsidrefundsOrderInformation(amountDetailsObj);
            var requestBody = new RefundCaptureRequest(clientReferenceInformationObj,null, null, orderInformationObj);

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/captures/5336232827876732903529/refunds",
                RequestJsonData = JsonConvert.SerializeObject(requestBody)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new RefundApi(configurationSwagger);
                var result = apiInstance.RefundCapture(requestBody, "5336232827876732903529");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
