using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches.CoreServices
{
    public class GetIndividualBatchFile
    {
        public static void Run()
        {
            try
            {
                var id = "Owcyk6pl";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TransactionBatchesApi(clientConfig);

                //var result = apiInstance.GetTransactionBatchId(id);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}