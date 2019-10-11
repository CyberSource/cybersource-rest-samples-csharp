using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Transaction_Batches
{
    public class GetListOfBatchFiles
    {
        public static PtsV1TransactionBatchesGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2019-05-22T01:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2019-07-22T22:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionBatchesApi(clientConfig);
                PtsV1TransactionBatchesGet200Response result = apiInstance.GetTransactionBatches(startTime, endTime);
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
