using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class GenerateKey
    {
        public static FlexV1KeysPost200Response Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(GenerateKey)}");

            CyberSource.Client.Configuration clientConfig = null;
            FlexV1KeysPost200Response result = null;

            var requestObj = new GeneratePublicKeyRequest("None");

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new KeyGenerationApi(clientConfig);

                result = apiInstance.GeneratePublicKey(requestObj);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception on calling the Sample Code({nameof(GenerateKey)}):{e.Message}");
                return null;
            }
            finally
            {
                if (clientConfig != null)
                {

                    Console.WriteLine("\nAPI REQUEST HEADERS:");

                    foreach (var requestHeader in clientConfig.ApiClient.ApiRequest.Headers)
                    {
                        Console.WriteLine(requestHeader);
                    }

                    Console.WriteLine("\nAPI REQUEST BODY:");
                    Console.WriteLine(clientConfig.ApiClient.ApiRequest.Data);

                    Console.WriteLine($"\nAPI RESPONSE CODE: {clientConfig.ApiClient.ApiResponse.StatusCode}");

                    Console.WriteLine("\nAPI RESPONSE HEADERS:");

                    foreach (var responseHeader in clientConfig.ApiClient.ApiResponse.HeadersList)
                    {
                        Console.WriteLine(responseHeader);
                    }

                    Console.WriteLine("\nAPI RESPONSE BODY:");
                    Console.WriteLine(clientConfig.ApiClient.ApiResponse.Data);

                    if (result != null)
                    {
                        Console.WriteLine("\nAPI RESPONSE DATA OBJECT:");
                        Console.WriteLine(result);
                    }

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(GenerateKey)}");
                }
            }
        }
    }
}