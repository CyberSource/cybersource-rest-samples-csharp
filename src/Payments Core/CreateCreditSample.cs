using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments_Core
{
    public class CreateCreditSample
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreateCreditRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "12345678"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsidrefundsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "Test",
                LastName = "test",
                PhoneNumber = "9999999999",
                Address1 = "test",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                AdministrativeArea = "MI",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "200",
                Currency = "usd"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsidrefundsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2paymentsidrefundsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                ExpirationMonth = "03",
                Type = "001"
            };

            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/credits",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new CreditApi(configurationSwagger);
                var result = apiInstance.CreateCredit(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
