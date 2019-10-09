using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.TransactionDetails.CoreServices
{
    public class RetrieveTransaction
    {
        public static void Run()
        {
            const string id = "5698452335976950303001";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new TransactionDetailsApi(clientConfig);

                var result = apiInstance.GetTransaction(id);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
