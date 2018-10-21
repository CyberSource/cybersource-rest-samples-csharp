using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RetrieveCapture
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            try
            {
                var capturePaymentId = CapturePayment.Run().Id;
                var apiInstance = new CaptureApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.GetCapture(capturePaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
