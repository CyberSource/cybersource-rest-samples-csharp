using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class ListPaymentInstrumentsForCustomer
    {
        public static PaymentInstrumentListForCustomer Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string profileid = null;
            long? offset = (long?)null;
            long? limit = (long?)null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerPaymentInstrumentApi(clientConfig);
                PaymentInstrumentListForCustomer result = apiInstance.GetCustomerPaymentInstrumentsList(customerTokenId, profileid, offset, limit);
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
