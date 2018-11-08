using System;
using System.Globalization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches.CoreServices
{
    public class GetListOfBatchFiles
    {
        public static void Run()
        {
            try
            {
                var startTime = "2018-08-11T22:47:57Z";
                var endTime = "2018-10-29T22:47:57Z";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TransactionBatchesApi(clientConfig);

                var result = apiInstance.PtsV1TransactionBatchesGet(startTime, endTime);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}