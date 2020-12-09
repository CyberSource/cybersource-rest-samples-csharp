using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateCustomerNonDefaultShippingAddress
    {
        public static Tmsv2customersEmbeddedDefaultShippingAddress Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            bool _default = false;
            string shipToFirstName = "John";
            string shipToLastName = "Doe";
            string shipToCompany = "CyberSource";
            string shipToAddress1 = "1 Market St";
            string shipToLocality = "San Francisco";
            string shipToAdministrativeArea = "CA";
            string shipToPostalCode = "94105";
            string shipToCountry = "US";
            string shipToEmail = "test@cybs.com";
            string shipToPhoneNumber = "4158880000";
            Tmsv2customersEmbeddedDefaultShippingAddressShipTo shipTo = new Tmsv2customersEmbeddedDefaultShippingAddressShipTo(
                FirstName: shipToFirstName,
                LastName: shipToLastName,
                Company: shipToCompany,
                Address1: shipToAddress1,
                Locality: shipToLocality,
                AdministrativeArea: shipToAdministrativeArea,
                PostalCode: shipToPostalCode,
                Country: shipToCountry,
                Email: shipToEmail,
                PhoneNumber: shipToPhoneNumber
           );

            var requestObj = new PostCustomerShippingAddressRequest(
                _Default: _default,
                ShipTo: shipTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerShippingAddressApi(clientConfig);
                Tmsv2customersEmbeddedDefaultShippingAddress result = apiInstance.PostCustomerShippingAddress(customerTokenId, requestObj);
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
