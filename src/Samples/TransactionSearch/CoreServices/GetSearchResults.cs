using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch.CoreServices
{
    public class GetSearchResults
    {
        public static void Run()
        {
            var id = "a50bdca7-8f76-499a-b5a6-be2df06afe1b";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SearchTransactionsApi(clientConfig);

                var result = apiInstance.GetSearch(id);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}