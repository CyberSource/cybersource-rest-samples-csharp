using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Simple_Auth
{
    public class RetailEmvContact
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC50171_16"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsPointOfSaleInformationObj = new V2paymentsPointOfSaleInformation
            {
                CardPresent = true,
                CatLevel = 1,
                EntryMode = "contact",
                TerminalCapability = 1

                // v2PaymentsPointOfSaleInformationObj.EndlessAisleTransactionIndicator = "true";
            };

            requestObj.PointOfSaleInformation = v2PaymentsPointOfSaleInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                CommerceIndicator = "retail",
                PaymentSolution = "011"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

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

            var v2PaymentsAggregatorInformationObj = new V2paymentsAggregatorInformation
            {
                SubMerchant = v2PaymentsAggregatorInformationSubMerchantObj,
                Name = "V-Internatio",
                AggregatorId = "123456789"
            };

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

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "115.0",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var v2PaymentsPaymentInformationFluidDataObj = new V2paymentsPaymentInformationFluidData
            {
                Descriptor = "EMV.PAYMENT.AnywhereCommerce.Walker",
                Value =
                    "ewogICJkYXRhIiA6ICJOZmNwRURiK1dLdzBnQkpsaTRcL1hlWm1ITzdUSng0bnRoMnc2Mk9ITVJQK3hCRlFPdFE0WWpRcnY0RmFkOHh6VExqT2VFQm5iNHFzeGZMYTNyNXcxVEdXblFGQnNzMWtPYnA0XC95alNtVE1JSGVjbGc5OFROaEhNb0VRcjJkRkFqYVpBTFAxSlBsdVhKSVwvbTZKSmVwNGh3VHRWZE16Z2laSUhnaWFCYzNXZVd1ZnYzc1l0cGRaZDZYZENEUFdLeXFkYjBJdUtkdkpBPT0iLAogICJzaWduYXR1cmUiIDogIkFxck1pKzc0cm1GeVBKVE9HN3NuN2p5K1YxTlpBZUNJVE56TW01N1B5cmc9IiwKICAic2lnbmF0dXJlQWxnSW5mbyIgOiAiSE1BQ3dpdGhTSEEyNTYiLAogICJoZWFkZXIiIDogewogICAgInRyYW5zYWN0aW9uSWQiIDogIjE1MTU2MjI2NjIuMTcyMjIwIiwKICAgICJwdWJsaWNLZXlIYXNoIiA6ICJcLzdmdldqRVhMazJPRWpcL3Z5bk1jeEZvMmRWSTlpRXVoT2Nab0tHQnpGTmM9IiwKICAgICJhcHBsaWNhdGlvbkRhdGEiIDogIkN5YmVyU291cmNlLlZNcG9zS2l0IiwKICAgICJlcGhlbWVyYWxQdWJsaWNLZXkiIDogIk1Ga3dFd1lIS29aSXpqMENBUVlJS29aSXpqMERBUWNEUWdBRW1JN0tScnRNN2NNelk5Zmw2UWt2NEQzdE9jU0NYR1hoOFwvK2R4K2s5c1Zrbk05UFQrOXRqMzk2YWF6QjRcL0hYaWlLRW9DXC9jUzdoSzF6UFk3MVwvN0pUUT09IgogIH0sCiAgInZlcnNpb24iIDogIjEuMCIKfQ=="
            };

            v2PaymentsPaymentInformationObj.FluidData = v2PaymentsPaymentInformationFluidDataObj;

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
