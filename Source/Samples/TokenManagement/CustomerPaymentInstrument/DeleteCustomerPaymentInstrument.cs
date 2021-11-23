using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class DeleteCustomerPaymentInstrument
    {
        public static void Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string paymentInstrumentTokenId = CreateCustomerNonDefaultPaymentInstrumentCard.Run().Id;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerPaymentInstrumentApi(clientConfig);
                apiInstance.DeleteCustomerPaymentInstrument(customerTokenId, paymentInstrumentTokenId);
                Console.WriteLine($"Customer Payment Instrument {customerTokenId} --> {paymentInstrumentTokenId} has been deleted.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
