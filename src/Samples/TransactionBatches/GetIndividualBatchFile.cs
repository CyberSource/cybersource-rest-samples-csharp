using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches
{
    public class GetIndividualBatchFile
    {
        public static PtsV1TransactionBatchesIdGet200Response Run()
        {
            try
            {
                var id = "12345";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionBatchesApi(clientConfig);
                PtsV1TransactionBatchesIdGet200Response result = apiInstance.GetTransactionBatchId(id);
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
