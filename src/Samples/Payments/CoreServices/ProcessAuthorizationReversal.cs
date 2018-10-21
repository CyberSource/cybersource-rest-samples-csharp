using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class ProcessAuthorizationReversal
    {
        public static InlineResponse2011 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var processPaymentId = ProcessPayment.Run().Id;

            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("test_reversal");
            var amount = new V2paymentsidreversalsOrderInformationLineItems(null, "102.21");
            var amountDetailsObj = new List<V2paymentsidreversalsOrderInformationLineItems> { amount };
            var orderInformationObj = new V2paymentsidreversalsOrderInformation(amountDetailsObj);
            var requestBody = new AuthReversalRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var apiInstance = new ReversalApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
                var result = apiInstance.AuthReversal(processPaymentId, requestBody);
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
