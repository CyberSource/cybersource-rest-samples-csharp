using CyberSource.Api;
using System;

namespace Cybersource_rest_samples_dotnet.Samples.NetworkToken
{
    public class PaymentCredentialsFromNetworkToken
    {
        public static string Run(string TokenId = null)
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            if (null == TokenId)
            {
                TokenId = CreateInstrumentIdentifierEnrollForNetworkToken.Run().Id;
            }
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TokenApi(clientConfig);
                var postPaymentCredentialsRequest = new PostPaymentCredentialsRequest();
                var result = apiInstance.PostTokenPaymentCredentials(TokenId, postPaymentCredentialsRequest, profileid);
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
