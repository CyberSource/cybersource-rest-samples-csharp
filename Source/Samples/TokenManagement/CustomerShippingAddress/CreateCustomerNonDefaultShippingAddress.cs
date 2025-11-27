using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateCustomerNonDefaultShippingAddress
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PostCustomerShippingAddressRequest Run()
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
            Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultShippingAddressShipTo shipTo = new Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultShippingAddressShipTo(
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
                Default: _default,
                ShipTo: shipTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerShippingAddressApi(clientConfig);
                PostCustomerShippingAddressRequest result = apiInstance.PostCustomerShippingAddress(customerTokenId, requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
