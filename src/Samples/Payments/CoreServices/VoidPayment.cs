using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidPayment
    {
        public static void Run()
        {
            ProcessPayment.CaptureTrueForProcessPayment = true;
            var processPaymentId = ProcessPayment.Run().Id;
            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_payment_void");
            var requestObj = new VoidPaymentRequest(clientReferenceInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new VoidApi(clientConfig);

                var result = apiInstance.VoidPayment(requestObj, processPaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
