using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CyberSource.Api;
using CyberSource.Model;
using CyberSource.Utilities.Flex.Model;
using CyberSource.Utilities.Flex.TokenVerification;

namespace Cybersource_rest_samples_dotnet.Samples.Flex.CoreServices
{
    public class TokenizeCard
    {
        public static void Run()
        {
            var generateKeyResult = GenerateKey.Run();
            var keyId = generateKeyResult.KeyId;
            var derFormat = generateKeyResult.Der.Format;
            var derAlgo = generateKeyResult.Der.Algorithm;
            var derPublicKey = generateKeyResult.Der.PublicKey;

            var requestObj = new TokenizeRequest
            (
                KeyId: keyId,
                CardInfo: new Flexv1tokensCardInfo
                (
                    CardExpirationYear: "2031",
                    CardNumber: "5555555555554444",
                    CardType: "002",
                    CardExpirationMonth: "03"
                )
            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TokenizationApi(clientConfig);

                var result = apiInstance.Tokenize(requestObj);
                Console.WriteLine(result);

                TokenVerificationUtility tokenVerifier = new TokenVerificationUtility();

                var flexPublicKey = new FlexPublicKey(keyId, new FlexDerPublicKey(derFormat, derAlgo, derPublicKey), null);
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

                IDictionary<string, string> postParameters = new Dictionary<string, string>();
                postParameters["signedFields"] = flexToken.signedFields;
                postParameters["signature"] = flexToken.signature;
                postParameters["cardType"] = flexToken.cardType;
                postParameters["keyId"] = flexToken.keyId;
                postParameters["maskedPan"] = flexToken.maskedPan;
                postParameters["token"] = flexToken.token;
                postParameters["timestamp"] = Convert.ToString(flexToken.timestamp);

                var tokenVerificationResult = tokenVerifier.Verify(flexPublicKey, postParameters);
                Console.WriteLine("TOKEN VERIFICATION : " + tokenVerificationResult);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
