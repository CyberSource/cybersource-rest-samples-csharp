using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Flex
{
    public class TokenizeCard
    {
        public static FlexV1TokensPost200Response Run()
        {
            string keyId = "08z9hCmn4pRpdNhPJBEYR3Mc2DGLWq5j";
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
