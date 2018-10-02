using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using FlexServerSDK;
using FlexServerSDK.Authentication;
using FlexServerSDK.Model;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using FlexServerSDK.Exception;

namespace CybsPayments.Flex
{
    public class TokenizeCard
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var generateKeyResult = GenerateKey.GenerateKeyResult(configDictionary);
            var keyId = generateKeyResult.KeyId;
            var derFormat = generateKeyResult.Der.Format;
            var derAlgo = generateKeyResult.Der.Algorithm;
            var derPublicKey = generateKeyResult.Der.PublicKey;

            var requestObj = new TokenizeRequest
            {
                KeyId = keyId,
                CardInfo = new Paymentsflexv1tokensCardInfo()
                {
                    CardExpirationYear = "2031",
                    CardNumber = "5555555555554444",
                    CardType = "002",
                    CardExpirationMonth = "03"
                }
            };

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/flex/v1/tokens",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new TokenizationApi(configurationSwagger);
                var result = apiInstance.Tokenize(requestObj);
                Console.WriteLine(result);

                var flexPublicKey = new FlexPublicKey(keyId, new FlexServerSDK.Model.DerPublicKey(derFormat, derAlgo, derPublicKey), null);
                var flexToken = new FlexToken()
                {
                    keyId = result.KeyId,
                    token = result.Token,
                    maskedPan = result.MaskedPan,
                    cardType = result.CardType,
                    timestamp = (long)result.Timestamp,
                    signedFields = result.SignedFields,
                    signature = result.Signature,
                    discoverableServices = result.DiscoverableServices
                };

                var tokenVerificationResult = Verify(
                    configDictionary["merchantID"],
                    configDictionary["merchantKeyId"],
                    configDictionary["merchantsecretKey"],
                    flexPublicKey,
                    flexToken);
                Console.WriteLine(tokenVerificationResult);

                //IDictionary<string, string> postParameters = new Dictionary<string, string>();
                //postParameters["signedFields"] = flexToken.signedFields;
                //postParameters["signature"] = flexToken.signature;

                //tokenVerificationResult = VerifyUsingRsa(flexPublicKey, postParameters);
                //Console.WriteLine(tokenVerificationResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }

        //public static bool VerifyUsingRsa(FlexPublicKey flexKey, IDictionary<string, string> postParameters)
        //{
        //    RSAParameters publicKey = DecodePublicKey(flexKey);

        //    string signedFields = (string)postParameters["signedFields"];

        //    StringBuilder sb = new StringBuilder();

        //    foreach (string k in signedFields.Split(','))
        //    {

        //        sb.Append(',');

        //        sb.Append(postParameters[k]);

        //    }

        //    if (sb.Length > 0) sb.Remove(0, 1);

        //    string signedValues = sb.ToString();

        //    string signature = (string)postParameters["signature"];

        //    return validateTokenSignature(publicKey, signedValues, signature);

        //}

        //private static bool validateTokenSignature(RSAParameters publicKey, string signedFields, string signature)
        //{

        //    bool success = false;

        //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        //    {

        //        byte[] bytesToVerify = DataHelper.GetBytes(signedFields);

        //        byte[] signedBytes = DataHelper.FromBase64String(signature);

        //        try
        //        {

        //            rsa.ImportParameters(publicKey);

        //            success = rsa.VerifyData(bytesToVerify, CryptoConfig.MapNameToOID("SHA512"), signedBytes);

        //        }
        //        catch (CryptographicException e)
        //        {

        //            throw new FlexSDKInternalException("Error validating signature", e);

        //        }
        //        catch (System.Exception e)
        //        {

        //            throw new FlexSDKInternalException("Error validating signature", e);

        //        }
        //        finally
        //        {

        //            rsa.PersistKeyInCsp = false;

        //        }

        //    }

        //    return success;

        //}

        private static bool Verify(string merchantId, string keyId, string secretKey, FlexPublicKey flexPublicKey, FlexToken flexTokenResponseBody)
        {
            // Verify function of FlexService class needs 2 objects: flexPublicKey and flexTokenResponseBody
            // These are being passed to the function

            // However creation of an instance of flexservice also needs 2 objects: flexCredentials and flexServiceConfiguration

            // Step 1: Creation of flexCredentials
            var secretKeyCharArray = secretKey.ToCharArray();
            SecureString sharedSecret = new SecureString();

            foreach (char c in secretKeyCharArray)
            {
                sharedSecret.AppendChar(c);
            }

            var environment = FlexServerSDK.Authentication.Environment.TEST;

            IFlexCredentials flexCredentials = new CyberSourceFlexCredentials(
                environment,
                merchantId,
                keyId,
                sharedSecret);

            int requestTimeout = 10000;
            IWebProxy proxy = null;
            bool enableDebugLogging = false;

            // Step 2: Creation of flexServiceConfiguration
            FlexServiceConfiguration flexServiceConfiguration = new FlexServiceConfigurationBuilder()
                .SetRequestTimeout(requestTimeout)
                .SetProxy(proxy)
                .SetDebugLoggingEnabled(enableDebugLogging)
                .Build();

            // Step3: Creation of instance of IFlexService
            IFlexService flexService = FlexServiceFactory.Create(flexCredentials, flexServiceConfiguration);

            // Final Step: Pass pubilc key and token to the Verify Function
            if (!flexService.Verify(flexPublicKey, flexTokenResponseBody))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
