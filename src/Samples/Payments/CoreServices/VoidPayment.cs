using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidPayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            ProcessPayment.CaptureTrueForProcessPayment = true;
            var processPaymentId = ProcessPayment.Run().Id;
            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_payment_void");
            var requestObj = new VoidPaymentRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
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
