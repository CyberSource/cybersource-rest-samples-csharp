using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RefundPayment
    {
        public static PtsV2PaymentsRefundPost201Response Run()
        {
            ProcessPayment.CaptureTrueForProcessPayment = true;
            var processPaymentId = ProcessPayment.Run().Id;

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation("test_refund_payment");
            var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails("10", "USD");
            var orderInformationObj = new Ptsv2paymentsidrefundsOrderInformation(amountDetailsObj);
            var requestBody = new RefundPaymentRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new RefundApi(clientConfig);

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