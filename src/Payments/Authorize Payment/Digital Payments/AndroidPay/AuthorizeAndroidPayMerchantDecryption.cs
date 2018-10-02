using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Digital_Payments.AndroidPay
{
    public class AuthorizeAndroidPayMerchantDecryption
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC_MPOS_Paymentech_1"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                PaymentSolution = "006"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                FirstName = "RTS",
                LastName = "VDP",
                PhoneNumber = "6504327113",
                Address2 = "Desk M3-5573",
                Address1 = "901 Metro Center Blvd",
                PostalCode = "94404",
                Locality = "Foster City",
                Company = "Visa",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "100",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var tokenizedCardObj = new V2paymentsPaymentInformationTokenizedCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                ExpirationMonth = "12",
                TransactionType = "1",
                Cryptogram = "AceY+igABPs3jdwNaDg3MAACAAA="
            };

            v2PaymentsPaymentInformationObj.TokenizedCard = tokenizedCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

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
