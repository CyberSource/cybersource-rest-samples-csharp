using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreatePaymentInstrument
    {
        public static TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedPaymentInstruments Run()
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var requestObj = new CreatePaymentInstrumentRequest();

            var cardObj = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedCard
            (
                ExpirationMonth: "09",
                ExpirationYear: "2022",
                Type: "visa"
            );

            requestObj.Card = cardObj;

            var billToObj = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBillTo
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

            var cardObj2 = new TmsV1InstrumentIdentifiersPost200ResponseCard
            {
                Number = "4111111111111111"
            };

            instrumentIdentifierObj.Card = cardObj2;

            requestObj.InstrumentIdentifier = instrumentIdentifierObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentInstrumentApi(clientConfig);

                var result = apiInstance.CreatePaymentInstrument(profileId, requestObj);
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
