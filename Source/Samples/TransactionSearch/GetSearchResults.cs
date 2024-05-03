using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionSearch
{
    public class GetSearchResults
    {
        public static TssV2TransactionsPost201Response Run()
        {
            var searchId = CreateSearchRequest.Run().SearchId;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new SearchTransactionsApi(clientConfig);
                TssV2TransactionsPost201Response result = apiInstance.GetSearch(searchId);
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
