using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.TMS.PaymentsWithToken
{
    public class AuthorizationWithToken
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation();

            clientReferenceInformationObj.Code = "TC50171_3";
            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var processingInformationObj = new V2paymentsProcessingInformation();

            processingInformationObj.CommerceIndicator = "internet";
            requestObj.ProcessingInformation = processingInformationObj;

            var aggregatorInformationObj = new V2paymentsAggregatorInformation();

            var subMerchantObj = new V2paymentsAggregatorInformationSubMerchant();

            subMerchantObj.CardAcceptorId = "1234567890";
            subMerchantObj.Country = "US";
            subMerchantObj.PhoneNumber = "650-432-0000";
            subMerchantObj.Address1 = "900 Metro Center";
            subMerchantObj.PostalCode = "94404-2775";
            subMerchantObj.Locality = "Foster City";
            subMerchantObj.Name = "Visa Inc";
            subMerchantObj.AdministrativeArea = "CA";
            subMerchantObj.Region = "PEN";
            subMerchantObj.Email = "test@cybs.com";
            aggregatorInformationObj.SubMerchant = subMerchantObj;

            aggregatorInformationObj.Name = "V-Internatio";
            aggregatorInformationObj.AggregatorId = "123456789";
            requestObj.AggregatorInformation = aggregatorInformationObj;

            var orderInformationObj = new V2paymentsOrderInformation();

            var billToObj = new V2paymentsOrderInformationBillTo();

            billToObj.Country = "US";
            billToObj.LastName = "VDP";
            billToObj.Address2 = "Address 2";
            billToObj.Address1 = "201 S. Division St.";
            billToObj.PostalCode = "48104-2201";
            billToObj.Locality = "Ann Arbor";
            billToObj.AdministrativeArea = "MI";
            billToObj.FirstName = "RTS";
            billToObj.PhoneNumber = "999999999";
            billToObj.District = "MI";
            billToObj.BuildingNumber = "123";
            billToObj.Company = "Visa";
            billToObj.Email = "test@cybs.com";
            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails();

            amountDetailsObj.TotalAmount = "22";
            amountDetailsObj.Currency = "USD";
            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            var paymentInformationObj = new V2paymentsPaymentInformation();

            var customerObj = new V2paymentsPaymentInformationCustomer();

            customerObj.CustomerId = "7500BB199B4270EFE05340588D0AFCAD";
            paymentInformationObj.Customer = customerObj;

            requestObj.PaymentInformation = paymentInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/",
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
