using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RetrievePayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            try
            {
                var apiInstance = new PaymentApi();
                var result = apiInstance.GetPayment("5319754772076048103525");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
