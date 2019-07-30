using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch.CoreServices
{
    public class CreateSearchRequest
    {
        public static void Run()
        {
            try
            {
                var requestObj = new CyberSource.Model.CreateSearchRequest()
                {
                    Save = false,
                    Name = "TSS search",
                    Timezone = "America/Chicago",
                    Query = "paymentInformation.card.number:4111111111111111",
                    Offset = 0,
                    Limit = 10,
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
