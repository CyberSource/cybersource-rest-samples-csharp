using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;
using CyberSource.Utilities.Flex.Model;
using CyberSource.Utilities.Flex.TokenVerification;

namespace Cybersource_rest_samples_dotnet.Samples.FlexMicroform
{
    public class FlexTokenizeCard
    {
        public static FlexV1TokensPost200Response Run()
        {
            var generateKeyResult = GenerateKeyLegacyTokenFormat.Run();
            string keyId = generateKeyResult.KeyId;
            var derFormat = generateKeyResult.Der.Format;
            var derAlgo = generateKeyResult.Der.Algorithm;
            var derPublicKey = generateKeyResult.Der.PublicKey;

            string cardInfoCardNumber = "4111111111111111";
            string cardInfoCardExpirationMonth = "12";
            string cardInfoCardExpirationYear = "2031";
            string cardInfoCardType = "001";
            Flexv1tokensCardInfo cardInfo = new Flexv1tokensCardInfo(
                CardNumber: cardInfoCardNumber,
                CardExpirationMonth: cardInfoCardExpirationMonth,
                CardExpirationYear: cardInfoCardExpirationYear,
                CardType: cardInfoCardType
           );

            var requestObj = new TokenizeRequest(
                KeyId: keyId,
                CardInfo: cardInfo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TokenizationApi(clientConfig);
                FlexV1TokensPost200Response result = apiInstance.Tokenize(requestObj);
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

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
