using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Purchase_Cards_Level_2
{
    public class Pcl2MasterCard
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC50171_12"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                CommerceIndicator = "internet"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsAggregatorInformationObj = new V2paymentsAggregatorInformation();

            var v2PaymentsAggregatorInformationSubMerchantObj = new V2paymentsAggregatorInformationSubMerchant
            {
                CardAcceptorId = "1234567890",
                Country = "US",
                PhoneNumber = "650-432-0000",
                Address1 = "900 Metro Center",
                PostalCode = "94404-2775",
                Locality = "Foster City",
                Name = "Visa Inc",
                AdministrativeArea = "CA",
                Region = "PEN",
                Email = "test@cybs.com"
            };

            v2PaymentsAggregatorInformationObj.SubMerchant = v2PaymentsAggregatorInformationSubMerchantObj;

            v2PaymentsAggregatorInformationObj.Name = "V-Internatio";
            v2PaymentsAggregatorInformationObj.AggregatorId = "123456789";
            requestObj.AggregatorInformation = v2PaymentsAggregatorInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "VDP",
                Address2 = "Address 2",
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

            var invoiceDetailsObj = new V2paymentsOrderInformationInvoiceDetails
            {
                PurchaseOrderNumber = "LevelII Auth Po"
            };

            v2PaymentsOrderInformationObj.InvoiceDetails = invoiceDetailsObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "112.00",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "5555555555554444",
                SecurityCode = "123",
                ExpirationMonth = "12",
                Type = "002"
            };

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
