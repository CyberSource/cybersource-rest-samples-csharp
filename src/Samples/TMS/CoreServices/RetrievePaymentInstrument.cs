using System;
using System.Collections.Generic;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class RetrievePaymentInstrument
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreatePaymentInstrument.Run().Id;

            try
            {
                var apiInstance = new PaymentInstrumentsApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
                var result = apiInstance.TmsV1PaymentinstrumentsTokenIdGet(profileId, tokenId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
