using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.PaymentsWithToken
{
    public class PaymentsInstrumentsForAuthorization
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new Body2();

            var paymentInformationCardObj = new PaymentinstrumentsCard();

            paymentInformationCardObj.ExpirationMonth = "09";
            paymentInformationCardObj.ExpirationYear = "2022";
            paymentInformationCardObj.Type = PaymentinstrumentsCard.TypeEnum.Visa;
            requestObj.Card = paymentInformationCardObj;

            var v2paymentsOrderInformationBillToObj = new PaymentinstrumentsBillTo();

            v2paymentsOrderInformationBillToObj.FirstName = "John";
            v2paymentsOrderInformationBillToObj.LastName = "Smith";
            v2paymentsOrderInformationBillToObj.Company = "CyberSource";
            v2paymentsOrderInformationBillToObj.Address1 = "12 Main Street";
            v2paymentsOrderInformationBillToObj.Address2 = "20 My Street";
            v2paymentsOrderInformationBillToObj.Locality = "San Francisco";
            v2paymentsOrderInformationBillToObj.AdministrativeArea = "CA";
            v2paymentsOrderInformationBillToObj.PostalCode = "90200";
            v2paymentsOrderInformationBillToObj.Country = "US";
            v2paymentsOrderInformationBillToObj.Email = "john.smith@example.com";
            v2paymentsOrderInformationBillToObj.PhoneNumber = "555123456";
            requestObj.BillTo = v2paymentsOrderInformationBillToObj;

            var instrumentIdentifierObj = new PaymentinstrumentsInstrumentIdentifier();

            var v2paymentsPaymentInformationCardObj = new InstrumentidentifiersCard();

            v2paymentsPaymentInformationCardObj.Number = "4111111111111111";
            instrumentIdentifierObj.Card = v2paymentsPaymentInformationCardObj;

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
