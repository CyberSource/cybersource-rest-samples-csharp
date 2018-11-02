using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidCapture
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var capturePaymentId = CapturePayment.Run().Id;
            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_capture_void");
            var requestBody = new VoidCaptureRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.VoidCapture(requestBody, capturePaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
