using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidPayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_payment_void");
            var requestObj = new VoidPaymentRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi();
                var result = apiInstance.VoidPayment(requestObj, "5395912009306755604005");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
