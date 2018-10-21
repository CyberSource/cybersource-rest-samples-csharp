using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionDetails
{
    public class TransactionDetail
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            const string id = "5330579740206278601009";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = $"/tss/v2/transactions/{id}"
            };

            try
            {
                Console.WriteLine("No Implementation");

                //var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                //var apiInstance = new TransactionDetailsApi(configurationSwagger);
                //var result = apiInstance.GetTransaction(id);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}