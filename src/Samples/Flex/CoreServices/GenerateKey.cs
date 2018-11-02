using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class GenerateKey
    {
        private static InlineResponse200 generateKeyResult;

        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new GeneratePublicKeyRequest("None");

            try
            {
                var apiInstance = new KeyGenerationApi();
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
