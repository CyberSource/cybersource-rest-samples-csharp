using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Digital_Payments.SamSung_Pay
{
    public class SamsungPayRetailRetailEmvContactless
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "33557799"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsPointOfSaleInformationObj = new V2paymentsPointOfSaleInformation
            {
                TerminalId = "terminal",
                CardPresent = true
            };

            var emvObj = new V2paymentsPointOfSaleInformationEmv
            {
                CardSequenceNumber = "123",
                Tags =
                    "9C01019A031207109F33036040209F1A0207849F370482766E409F3602001F82025C009F2608EF7753429A5D16B19F100706010A03A00000950580000400009F02060000000700009F6E0482766E409F5B04123456789F2701809F3403AB12349F0902AB129F4104AB1234AB9F0702AB129F0610123456789012345678901234567890AB9F030200005F2A0207849F7C031234569F350123"
            };

            v2PaymentsPointOfSaleInformationObj.Emv = emvObj;

            v2PaymentsPointOfSaleInformationObj.EntryMode = "contactless";
            v2PaymentsPointOfSaleInformationObj.TerminalCapability = 4;
            requestObj.PointOfSaleInformation = v2PaymentsPointOfSaleInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                CommerceIndicator = "retail",
                PaymentSolution = "008"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "VDP",
                Address2 = "test",
                Address1 = "201 S. Division St.",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                AdministrativeArea = "MI",
                FirstName = "RTS",
                PhoneNumber = "999999999",
                District = "MI",
                BuildingNumber = "123",
                Company = "Visa",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var tokenizedCardObj = new V2paymentsPaymentInformationTokenizedCard
            {
                TransactionType = "1",
                RequestorId = "12345678901"
            };

            v2PaymentsPaymentInformationObj.TokenizedCard = tokenizedCardObj;

            var v2PaymentsPaymentInformationCardObj = new V2paymentsPaymentInformationCard
            {
                Type = "001"
            };

            // v2paymentsPaymentInformationCardObj.TrackData = ";4111111111111111=21121019761186800000?";
            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

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
