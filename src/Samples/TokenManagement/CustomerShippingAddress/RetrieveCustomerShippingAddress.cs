using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class RetrieveCustomerShippingAddress
    {
        public static Tmsv2customersEmbeddedDefaultShippingAddress Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string shippingAddressTokenId = "AB6A54B97C00FCB6E05341588E0A3935";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerShippingAddressApi(clientConfig);
                Tmsv2customersEmbeddedDefaultShippingAddress result = apiInstance.GetCustomerShippingAddress(customerTokenId, shippingAddressTokenId);
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
