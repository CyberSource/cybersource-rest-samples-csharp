using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RefundPayment
    {
        public static InlineResponse2013 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            ProcessPayment.CaptureTrueForProcessPayment = true;
            var processPaymentId = ProcessPayment.Run().Id;

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation("test_refund_payment");
            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails("10", "USD");
            var orderInformationObj = new V2paymentsidrefundsOrderInformation(amountDetailsObj);
            var requestBody = new RefundPaymentRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var apiInstance = new RefundApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.RefundPayment(requestBody, processPaymentId);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
