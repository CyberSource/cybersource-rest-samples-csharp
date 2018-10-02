using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.All_Services
{
    public class AuthorizationOnly
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation {Code = "1234567890"};

            var pointOfSaleInformationObj = new V2paymentsPointOfSaleInformation
            {
                CardPresent = false,
                CatLevel = 6,
                TerminalCapability = 4
            };

            var orderInformationObj = new V2paymentsOrderInformation();

            var billToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                FirstName = "RTS",
                LastName = "VDP",
                Address1 = "901 Metro Center Blvd",
                PostalCode = "40500",
                Locality = "Foster City",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            var paymentInformationObj = new V2paymentsPaymentInformation();

            var cardObj = new V2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                SecurityCode = "123",
                ExpirationMonth = "12"
            };

            paymentInformationObj.Card = cardObj;

            var requestObj = new CreatePaymentRequest
            {
                PaymentInformation = paymentInformationObj,
                ClientReferenceInformation = clientReferenceInformationObj,
                PointOfSaleInformation = pointOfSaleInformationObj,
                OrderInformation = orderInformationObj
            };

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new PaymentApi(configurationSwagger);
                var result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
