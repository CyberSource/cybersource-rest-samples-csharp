using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidRefund
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var refundPaymentId = RefundPayment.Run().Id;

            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_refund_void");
            var requestBody = new VoidRefundRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
                var result = apiInstance.VoidRefund(requestBody, refundPaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
