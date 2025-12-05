using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Cybersource_rest_samples_dotnet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionBatches
{
    public class UploadTransactionBatch
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static void Run()
        {
            // Get the file path from the resources folder
            String filename = "batchapiTest.csv";

            Stream file = null;
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Source\\Resource", filename);
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File Not Found : Kindly verify the path.");
            }

            try
            {
                var configDictionary = new Cybersource_rest_samples_dotnet.Configuration().GetMerchantDetailsForBatchUploadSample();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TransactionBatchesApi(clientConfig);
                ApiResponse<object> result = apiInstance.UploadTransactionBatchWithHttpInfo(file);
                Console.WriteLine(result);
                WriteLogAudit(result.StatusCode);
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
            }
        }

    }
}
