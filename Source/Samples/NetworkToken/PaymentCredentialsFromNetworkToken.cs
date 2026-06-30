using CyberSource.Api;
using CyberSource.Model;
using System;

namespace Cybersource_rest_samples_dotnet.Samples.NetworkToken
{
    public class PaymentCredentialsFromNetworkToken
    {
        public static async System.Threading.Tasks.Task<string> RunAsync(string TokenId = null)
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            if (null == TokenId)
            {
                TokenId = (await CreateInstrumentIdentifierEnrollForNetworkToken.RunAsync()).Id;
            }
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new NetworkTokensApi(clientConfig);
                var postPaymentCredentialsRequest = new PostPaymentCredentialsRequest1();
                var result = await apiInstance.PostTokenPaymentCredentialsAsync(TokenId, postPaymentCredentialsRequest, profileid);
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
