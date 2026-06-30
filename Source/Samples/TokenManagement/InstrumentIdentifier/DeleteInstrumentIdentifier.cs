using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class DeleteInstrumentIdentifier
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static async System.Threading.Tasks.Task RunAsync()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = (await CreateInstrumentIdentifierCard.RunAsync()).Id;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                await apiInstance.DeleteInstrumentIdentifierAsync(tokenId, profileid);
                Console.WriteLine($"Instrument Identifier {tokenId} has been deleted.");
                WriteLogAudit(apiInstance.GetStatusCode());
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
            }
        }
    }
}
