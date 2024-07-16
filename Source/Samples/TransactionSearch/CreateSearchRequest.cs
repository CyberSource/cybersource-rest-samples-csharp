using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch
{
    public class CreateSearchRequest
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static TssV2TransactionsPost201Response Run()
        {
            bool save = false;
            string name = "MRN";
            string timezone = "America/Chicago";
            string query = "clientReferenceInformation.code:TC50171_3 AND submitTimeUtc:[NOW/DAY-7DAYS TO NOW/DAY+1DAY}";
            int offset = 0;
            int limit = 100;
            string sort = "id:asc,submitTimeUtc:asc";
            var requestObj = new CyberSource.Model.CreateSearchRequest(
                Save: save,
                Name: name,
                Timezone: timezone,
                Query: query,
                Offset: offset,
                Limit: limit,
                Sort: sort
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new SearchTransactionsApi(clientConfig);
                TssV2TransactionsPost201Response result = apiInstance.CreateSearch(requestObj);
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
