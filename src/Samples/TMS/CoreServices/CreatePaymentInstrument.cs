using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreatePaymentInstrument
    {
        public static InlineResponse2016 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var requestObj = new Body2();

            var cardObj = new Tmsv1paymentinstrumentsCard
            {
                ExpirationMonth = "09",
                ExpirationYear = "2022",
                Type = Tmsv1paymentinstrumentsCard.TypeEnum.Visa
            };

            requestObj.Card = cardObj;

            var billToObj = new Tmsv1paymentinstrumentsBillTo
            {
                FirstName = "John",
                LastName = "Smith",
                Company = "CyberSource",
                Address1 = "12 Main Street",
                Address2 = "20 My Street",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                PostalCode = "90200",
                Country = "US",
                Email = "john.smith@example.com",
                PhoneNumber = "555123456"
            };

            requestObj.BillTo = billToObj;

            var instrumentIdentifierObj = new Tmsv1paymentinstrumentsInstrumentIdentifier();

            var cardObj2 = new Tmsv1instrumentidentifiersCard
            {
                Number = "4111111111111111"
            };

            instrumentIdentifierObj.Card = cardObj2;

            requestObj.InstrumentIdentifier = instrumentIdentifierObj;

            try
            {
                var apiInstance = new PaymentInstrumentsApi();
                var result = apiInstance.TmsV1PaymentinstrumentsPost(profileId, requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
