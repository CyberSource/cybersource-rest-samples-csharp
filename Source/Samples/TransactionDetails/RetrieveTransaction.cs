using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Cybersource_rest_samples_dotnet.Samples.Payments;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionDetails
{
    public class RetrieveTransaction
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static async System.Threading.Tasks.Task<TssV2TransactionsGet200Response> RunAsync()
        {
            string id = (await SimpleAuthorizationInternet.RunAsync()).Id;

            System.Threading.Thread.Sleep(15000);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionDetailsApi(clientConfig);
                TssV2TransactionsGet200Response result = await apiInstance.GetTransactionAsync(id);
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
