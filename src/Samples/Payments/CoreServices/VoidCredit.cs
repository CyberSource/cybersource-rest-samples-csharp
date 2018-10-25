using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class VoidCredit
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var processCreditId = ProcessCredit.Run().Id;

            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_credit_void");
            var requestBody = new VoidCreditRequest(clientReferenceInformationObj);

            try
            {
                var apiInstance = new VoidApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.VoidCredit(requestBody, processCreditId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
