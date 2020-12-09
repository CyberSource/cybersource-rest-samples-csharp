using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class EnrollInstrumentIdentifierForNetworkTokenization
    {
        public static void Run()
        {
            string instrumentIdentifierTokenId = "7010000000016241111";
            string profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string type = "enrollable card";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardSecurityCode = "123";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierCard card = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierCard(
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                SecurityCode: cardSecurityCode
           );

            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierBillTo billTo = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierBillTo(
                Address1: billToAddress1,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry
           );

            var requestObj = new PostInstrumentIdentifierEnrollmentRequest(
                Type: type,
                Card: card,
                BillTo: billTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                apiInstance.PostInstrumentIdentifierEnrollment(instrumentIdentifierTokenId, requestObj, profileid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
