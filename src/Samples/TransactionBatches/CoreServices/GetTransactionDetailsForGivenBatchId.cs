// Code Generated: getTransactionBatchDetails[Get transaction details for a given batch id]

using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches.CoreServices
{
    public class GetTransactionDetailsForGivenBatchId
    {
        public static void Run()
        {
            var id = "12345";
            var uploadDate = DateTime.ParseExact("2019-05-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var status = "REJECTED";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionBatchesApi(clientConfig);
                apiInstance.GetTransactionBatchDetails(id, uploadDate, status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}