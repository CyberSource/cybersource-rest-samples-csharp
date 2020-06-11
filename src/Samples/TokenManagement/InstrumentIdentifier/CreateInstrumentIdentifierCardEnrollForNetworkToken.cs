using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateInstrumentIdentifierCardEnrollForNetworkToken
    {
        public static TmsV1InstrumentIdentifiersPost200Response Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            string type = "enrollable card";
            string cardNumber = "4622943127013705";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2022";
            string cardSecurityCode = "838";
            Tmsv1instrumentidentifiersCard card = new Tmsv1instrumentidentifiersCard(
                Number: cardNumber,
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                SecurityCode: cardSecurityCode
           );

            string billToAddress1 = "8310 Capital of Texas Highway North";
            string billToAddress2 = "Bluffstone Drive";
            string billToLocality = "Austin";
            string billToAdministrativeArea = "TX";
            string billToPostalCode = "78731";
            string billToCountry = "US";
            Tmsv1instrumentidentifiersBillTo billTo = new Tmsv1instrumentidentifiersBillTo(
                Address1: billToAddress1,
                Address2: billToAddress2,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry
           );

            var requestObj = new CreateInstrumentIdentifierRequest(
                Type: type,
                Card: card,
                BillTo: billTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                TmsV1InstrumentIdentifiersPost200Response result = apiInstance.CreateInstrumentIdentifier(profileid, requestObj);
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
