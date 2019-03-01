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
                Console.WriteLine($"\nException on calling the Sample Code({nameof(GenerateKey)}):{e.Message}");
                return null;
            }
            finally
            {
                if (clientConfig != null)
                {
                    // PRINTING REQUEST DETAILS
                    if (clientConfig.ApiClient.Configuration.RequestHeaders != null)
                    {
                        Console.WriteLine("\nAPI REQUEST HEADERS:");
                        foreach (var requestHeader in clientConfig.ApiClient.Configuration.RequestHeaders)
                        {
                            Console.WriteLine(requestHeader);
                        }
                    }

                    if (!string.IsNullOrEmpty(clientConfig.ApiClient.Configuration.RequestBody))
                    {
                        Console.WriteLine("\nAPI REQUEST BODY:");
                        Console.WriteLine(clientConfig.ApiClient.Configuration.RequestBody);
                    }

                    // PRINTING RESPONSE DETAILS
                    if (clientConfig.ApiClient.ApiResponse != null)
                    {
                        if (!string.IsNullOrEmpty(clientConfig.ApiClient.ApiResponse.StatusCode.ToString()))
                        {
                            Console.WriteLine($"\nAPI RESPONSE CODE: {clientConfig.ApiClient.ApiResponse.StatusCode}");
                        }

                        Console.WriteLine("\nAPI RESPONSE HEADERS:");

                        foreach (var responseHeader in clientConfig.ApiClient.ApiResponse.HeadersList)
                        {
                            Console.WriteLine(responseHeader);
                        }

                        Console.WriteLine("\nAPI RESPONSE BODY:");
                        Console.WriteLine(clientConfig.ApiClient.ApiResponse.Data);
                    }

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(GenerateKey)}");
                }
            }
        }
    }
}