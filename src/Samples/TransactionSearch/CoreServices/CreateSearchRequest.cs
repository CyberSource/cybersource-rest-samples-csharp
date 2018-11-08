using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch.CoreServices
{
    public class CreateSearchRequest
    {
        public static void Run()
        {
            try
            {
                var requestObj = new CyberSource.Model.TssV2TransactionsPostResponse()
                {
                    Save = false,
                    Name = "TSS search",
                    Timezone = "America/Chicago",
                    Query = "clientReferenceInformation.code:12345",
                    Offset = 0,
                    Limit = 100,
                    Sort = "id:asc, submitTimeUtc:asc"
                };

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SearchTransactionsApi(clientConfig);

                var result = apiInstance.CreateSearch(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
