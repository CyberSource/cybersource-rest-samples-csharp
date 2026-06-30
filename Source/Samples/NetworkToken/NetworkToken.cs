using CyberSource.Utilities;

using System.Collections.Generic;
using AuthenticationSdk.core;
using System;
using CyberSource.Model;
using System.Security.Cryptography;
using System.IO;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Parameters;

namespace Cybersource_rest_samples_dotnet.Samples.NetworkToken
{
    public class NetworkToken
    {
        public static async System.Threading.Tasks.Task<String> RunAsync()
        {

            Dictionary<string, string> configDictionary = new Configuration().GetConfiguration();

            MerchantConfig merchantConfig = new MerchantConfig(configDictionary);
            
            try
            {
                // Step-I
                PostInstrumentIdentifierRequest createInstrumentIdentifierEnrollForNetworkTokenResponse = await CreateInstrumentIdentifierEnrollForNetworkToken.RunAsync();

                //Step-II
                var encodedResponse = await PaymentCredentialsFromNetworkToken.RunAsync(createInstrumentIdentifierEnrollForNetworkTokenResponse.Id);

                //Step-III
                //The following method JWEUtility.DecryptJWEResponse(string, MerchantConfig) has been deprecated.
                //var result = JWEUtility.DecryptJWEResponse(encodedResponse, merchantConfig);

                //Using the new method JWEUtility.DecryptJWEResponse(RSAParamet ers, string) instead
                //RSAParameters rsaParams = FetchRSAParametersFromFile(merchantConfig.PemFileDirectory);
                //var result = JWEUtility.DecryptJWEResponse(rsaParams, encodedResponse);

                Console.WriteLine(encodedResponse);
                return encodedResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while decrypting the JWE Response : " + e.Message);
                return null;
            }
        }

        private static RSAParameters FetchRSAParametersFromFile(string pemFileDirectory)
        {
            var privateKey = File.ReadAllText(pemFileDirectory);
            PemReader pemReader = new PemReader(new StringReader(privateKey));
            object pemObject = pemReader.ReadObject();

            RsaPrivateCrtKeyParameters keyParameters = pemObject as RsaPrivateCrtKeyParameters
                ?? (pemObject as AsymmetricCipherKeyPair)?.Private as RsaPrivateCrtKeyParameters;

            if (keyParameters == null)
            {
                throw new InvalidCastException("The PEM file does not contain a valid RSA private key.");
            }

            return DotNetUtilities.ToRSAParameters(keyParameters);
        }
    }
}
