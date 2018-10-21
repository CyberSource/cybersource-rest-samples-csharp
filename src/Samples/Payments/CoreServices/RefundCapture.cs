using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RefundCapture
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var capturePaymentId = CapturePayment.Run().Id;

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation("test_refund_capture");
            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails("102.21", "USD");
            var orderInformationObj = new V2paymentsidrefundsOrderInformation(amountDetailsObj);
            var requestBody = new RefundCaptureRequest(clientReferenceInformationObj,null, null, orderInformationObj);

            try
            {
                var apiInstance = new RefundApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.RefundCapture(requestBody, capturePaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
