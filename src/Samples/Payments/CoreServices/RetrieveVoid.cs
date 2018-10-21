using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RetrieveVoid
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            try
            {
                var apiInstance = new VoidApi();
                var result = apiInstance.GetVoid("5335528892726038303523");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
