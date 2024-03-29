using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class DeleteCustomerShippingAddress
    {
        public static void Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string shippingAddressTokenId = CreateCustomerNonDefaultShippingAddress.Run().Id;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerShippingAddressApi(clientConfig);
                apiInstance.DeleteCustomerShippingAddress(customerTokenId, shippingAddressTokenId);
                Console.WriteLine($"Customer Shipping Address {customerTokenId} --> {shippingAddressTokenId} has been deleted.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
