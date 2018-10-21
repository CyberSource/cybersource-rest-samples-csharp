using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class GenerateKey
    {
        private static InlineResponse200 generateKeyResult;

        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new GeneratePublicKeyRequest
            {
                EncryptionType = "None"
            };

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/flex/v1/keys",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new KeyGenerationApi(configurationSwagger);
                var result = apiInstance.GeneratePublicKey(requestObj);
                generateKeyResult = result;
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }

        public static InlineResponse200 GenerateKeyResult(IReadOnlyDictionary<string, string> configDictionary)
        {
            Run(configDictionary);
            return generateKeyResult;
        }
    }
}
