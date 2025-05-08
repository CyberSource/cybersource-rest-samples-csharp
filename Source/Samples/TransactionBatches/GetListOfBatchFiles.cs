using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches
{
    public class GetListOfBatchFiles
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PtsV1TransactionBatchesGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2020-02-22T01:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2020-02-22T22:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionBatchesApi(clientConfig);
                PtsV1TransactionBatchesGet200Response result = apiInstance.GetTransactionBatches(startTime, endTime);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
