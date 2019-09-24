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
                var startTime = DateTime.ParseExact("2019-08-11T22:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                var endTime = DateTime.ParseExact("2019-08-29T22:47:57Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TransactionBatchesApi(clientConfig);

                var result = apiInstance.GetTransactionBatches(startTime, endTime);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}