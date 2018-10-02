using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.All_Services
{
    public class AuthReversal
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation {Code = "Testing"};

            var amount = new V2paymentsidreversalsOrderInformationLineItems {UnitPrice = "102.21"};

            var amountDetailsObj = new List<V2paymentsidreversalsOrderInformationLineItems> { amount };

            var orderInformationObj = new V2paymentsidreversalsOrderInformation(amountDetailsObj);

            var requestBody = new AuthReversalRequest {ClientReferenceInformation = clientReferenceInformationObj, OrderInformation = orderInformationObj};

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5348536157836314704006/reversals",
                RequestJsonData = JsonConvert.SerializeObject(requestBody)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new ReversalApi(configurationSwagger);
                var result = apiInstance.AuthReversal("5348536157836314704006", requestBody);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
