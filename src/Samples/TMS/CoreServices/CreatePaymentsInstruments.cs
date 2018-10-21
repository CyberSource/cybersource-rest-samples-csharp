using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreatePaymentsInstruments
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new Body2();

            var cardObj = new PaymentinstrumentsCard();

            cardObj.ExpirationMonth = "09";
            cardObj.ExpirationYear = "2022";
            cardObj.Type = PaymentinstrumentsCard.TypeEnum.Visa;
            requestObj.Card = cardObj;

            var billToObj = new PaymentinstrumentsBillTo();

            billToObj.FirstName = "John";
            billToObj.LastName = "Smith";
            billToObj.Company = "CyberSource";
            billToObj.Address1 = "12 Main Street";
            billToObj.Address2 = "20 My Street";
            billToObj.Locality = "San Francisco";
            billToObj.AdministrativeArea = "CA";
            billToObj.PostalCode = "90200";
            billToObj.Country = "US";
            billToObj.Email = "john.smith@example.com";
            billToObj.PhoneNumber = "555123456";
            requestObj.BillTo = billToObj;

            var instrumentIdentifierObj = new PaymentinstrumentsInstrumentIdentifier();

            var cardObj2 = new InstrumentidentifiersCard();

            cardObj2.Number = "4111111111111111";
            instrumentIdentifierObj.Card = cardObj2;

            requestObj.InstrumentIdentifier = instrumentIdentifierObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/tms/v1/paymentinstruments",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new PaymentInstrumentApi(configurationSwagger);
                var result = apiInstance.PaymentinstrumentsPost("93B32398-AD51-4CC2-A682-EA3E93614EB1", requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
