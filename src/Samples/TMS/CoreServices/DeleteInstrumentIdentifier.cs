using System;
using System.Collections.Generic;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class DeleteInstrumentIdentifier
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreateInstrumentIdentifier.Run().Id;

            try
            {
                var apiInstance = new InstrumentIdentifierApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
                var result = apiInstance.InstrumentidentifiersTokenIdDeleteWithHttpInfo(profileId, tokenId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
