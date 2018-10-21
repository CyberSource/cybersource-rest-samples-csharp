using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RetrieveCredit
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            try
            {
                var apiInstance = new CreditApi();
                var result = apiInstance.GetCredit("5332036920866055004101");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
