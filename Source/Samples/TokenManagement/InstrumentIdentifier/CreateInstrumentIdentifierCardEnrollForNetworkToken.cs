using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateInstrumentIdentifierCardEnrollForNetworkToken
    {
        public static TmsEmbeddedInstrumentIdentifier Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            string type = "enrollable card";
            string cardNumber = "4111111111111111";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardSecurityCode = "123";
            TmsEmbeddedInstrumentIdentifierCard card = new TmsEmbeddedInstrumentIdentifierCard(
                Number: cardNumber,
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                SecurityCode: cardSecurityCode
           );

            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            TmsEmbeddedInstrumentIdentifierBillTo billTo = new TmsEmbeddedInstrumentIdentifierBillTo(
                Address1: billToAddress1,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry
           );

            var requestObj = new PostInstrumentIdentifierRequest(
                Type: type,
                Card: card,
                BillTo: billTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                TmsEmbeddedInstrumentIdentifier result = apiInstance.PostInstrumentIdentifier(requestObj, profileid);
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
