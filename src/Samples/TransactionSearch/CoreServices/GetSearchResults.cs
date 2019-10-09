using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch.CoreServices
{
    public class GetSearchResults
    {
        public static void Run()
        {
            var id = "cd46194f-b41f-4084-990a-7ea1f28aa831";

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