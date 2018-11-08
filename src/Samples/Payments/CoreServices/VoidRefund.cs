using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidRefund
    {
        public static void Run()
        {
            var refundPaymentId = RefundPayment.Run().Id;

            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_refund_void");
            var requestBody = new VoidRefundRequest(clientReferenceInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new VoidApi(clientConfig);

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
