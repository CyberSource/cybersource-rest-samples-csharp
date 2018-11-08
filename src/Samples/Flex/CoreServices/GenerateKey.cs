using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class GenerateKey
    {
        public static FlexV1KeysPost200Response Run()
        {
            var requestObj = new GeneratePublicKeyRequest("None");

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new KeyGenerationApi(clientConfig);

                var result = apiInstance.GeneratePublicKey(requestObj);
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
