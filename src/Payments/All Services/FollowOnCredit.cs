using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.All_Services
{
    public class FollowOnCredit
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new RefundCaptureRequest();

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC12345"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var buyerInformationObj = new V2paymentsidcapturesBuyerInformation
            {
                MerchantCustomerId = "123456abcd"
            };

            requestObj.BuyerInformation = buyerInformationObj;

            var subMerchantObj = new V2paymentsidcapturesAggregatorInformationSubMerchant
            {
                Country = "US",
                PhoneNumber = "650-432-0000",
                Address1 = "900 Metro Center",
                PostalCode = "94404-2775",
                Locality = "Foster City",
                Name = "Visa Inc",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"

                // subMerchantObj.CardAcceptorID = "1234567890";
                // subMerchantObj.Region = "PEN";
            };

            var aggregatorInformationObj = new V2paymentsidcapturesAggregatorInformation
            {
                SubMerchant = subMerchantObj,
                Name = "V-Internatio",
                AggregatorId = "123456789"
            };

            requestObj.AggregatorInformation = aggregatorInformationObj;

            var orderInformationObj = new V2paymentsidrefundsOrderInformation();

            var shippingDetailsObj = new V2paymentsidcapturesOrderInformationShippingDetails
            {
                ShipFromPostalCode = "47404"
            };

            orderInformationObj.ShippingDetails = shippingDetailsObj;

            var billToObj = new V2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Test",
                PhoneNumber = "9999999",
                Address2 = "test2credit",
                Address1 = "testcredit",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                Company = "Visa",
                AdministrativeArea = "MI",
                Email = "test2@cybs.com"
            };

            orderInformationObj.BillTo = billToObj;

            var invoiceDetailsObj = new V2paymentsidcapturesOrderInformationInvoiceDetails
            {
                PurchaseOrderDate = "20111231",
                PurchaseOrderNumber = "CREDIT US"
            };

            orderInformationObj.InvoiceDetails = invoiceDetailsObj;

            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "100",
                ExchangeRate = "0.5",
                ExchangeRateTimeStamp = "2.01304E+13",
                Currency = "usd"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            var merchantInformationObj = new V2paymentsidrefundsMerchantInformation
            {
                CategoryCode = 1234
            };

            requestObj.MerchantInformation = merchantInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/captures/5336232827876732903529/refunds",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new RefundApi(configurationSwagger);
                var result = apiInstance.RefundCapture(requestObj, "5336232827876732903529");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
