using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidCredit
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_credit_void");
            var requestBody = new VoidCreditRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi();
                var result = apiInstance.VoidCredit(requestBody, "5395911486196754404005");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
