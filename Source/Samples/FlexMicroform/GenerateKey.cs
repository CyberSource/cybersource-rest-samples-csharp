using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.FlexMicroform
{
    public class GenerateKey
    {
        /*public static FlexV1KeysPost200Response Run()
        {
            string encryptionType = "RsaOaep";
            string targetOrigin = "https://www.test.com";
            var requestObj = new GeneratePublicKeyRequest(
                EncryptionType: encryptionType,
                TargetOrigin: targetOrigin
           );

            string format = "JWT";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new KeyGenerationApi(clientConfig);
                FlexV1KeysPost200Response result = apiInstance.GeneratePublicKey(format, requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        } */
    }
}
