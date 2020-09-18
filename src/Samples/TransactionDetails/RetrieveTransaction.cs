using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;
using Cybersource_rest_samples_dotnet.Samples.Payments;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionDetails
{
    public class RetrieveTransaction
    {
        public static TssV2TransactionsGet200Response Run()
        {
            string id = SimpleAuthorizationInternet.Run().Id;

            System.Threading.Thread.Sleep(10000);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TransactionDetailsApi(clientConfig);
                TssV2TransactionsGet200Response result = apiInstance.GetTransaction(id);
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
