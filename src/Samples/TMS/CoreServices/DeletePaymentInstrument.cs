using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class DeletePaymentInstrument
    {
        public static void Run()
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreatePaymentInstrument.Run().Id;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentInstrumentApi(clientConfig);

                apiInstance.DeletePaymentInstrument(profileId, tokenId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
