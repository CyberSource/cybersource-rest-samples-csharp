using CyberSource.Utilities;

using System.Collections.Generic;
using AuthenticationSdk.core;
using System;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.NetworkToken
{
    public class NetworkToken
    {
        public static String Run()
        {

            Dictionary<string, string> configDictionary = new Configuration().GetConfiguration();

            MerchantConfig merchantConfig = new MerchantConfig(configDictionary);
            
            try
            {
                // Step-I
                Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifier tmsv2CustomersEmbeddedDefaultPaymentInstrumentEmbedded = CreateInstrumentIdentifierEnrollForNetworkToken.Run();

                //Step-II
                var encodedResponse = PaymentCredentialsFromNetworkToken.Run(tmsv2CustomersEmbeddedDefaultPaymentInstrumentEmbedded.Id);

                //Step-III
                var result = JWEUtility.DecryptJWEResponse(encodedResponse, merchantConfig);

                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while decrypting the JWE Response : " + e.Message);
                return null;
            }
        }
    }
}
