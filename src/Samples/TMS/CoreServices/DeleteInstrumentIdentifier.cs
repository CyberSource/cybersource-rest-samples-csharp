using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class DeleteInstrumentIdentifier
    {
        public static void Run()
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreateInstrumentIdentifier.Run().Id;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new InstrumentIdentifierApi(clientConfig);

                apiInstance.TmsV1InstrumentidentifiersTokenIdDelete(profileId, tokenId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
