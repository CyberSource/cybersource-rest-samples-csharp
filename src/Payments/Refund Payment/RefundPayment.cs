using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Refund_Payment
{
    public class RefundPayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {

            var requestObj = new RefundPaymentRequest();

            var v2PaymentsOrderInformationObj = new V2paymentsidrefundsOrderInformation();

            var shippingDetailsObj = new V2paymentsidcapturesOrderInformationShippingDetails
            {
                ShipFromPostalCode = "47404"
            };

            v2PaymentsOrderInformationObj.ShippingDetails = shippingDetailsObj;

            var v2PaymentsOrderInformationBillToObj = new V2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Test",
                PhoneNumber = "9999999",
                Address2 = "test2",
                Address1 = "test",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                Company = "Visa",
                AdministrativeArea = "MI",
                Email = "test2@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "100",
                ExchangeRate = "0.5",
                ExchangeRateTimeStamp = "2.01304E+13",
                Currency = "usd"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            var shipToObj = new V2paymentsidcapturesOrderInformationShipTo
            {
                Country = "US",
                PostalCode = "48104-2202",
                AdministrativeArea = "MI"
            };

            // shipToObj.Address2 = "test2";
            // shipToObj.Address1 = "test";
            v2PaymentsOrderInformationObj.ShipTo = shipToObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsidrefundsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2paymentsidrefundsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "5555555555554444",
                ExpirationMonth = "12",
                Type = "002"
            };

            // v2paymentsPaymentInformationCardObj.SecurityCode = "123";
            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            // var processingInformationObj = new V2paymentsidrefundsProcessingInformation()
            // {
            //     capture = true
            // };
            var lineItemsObj = new V2paymentsidrefundsOrderInformationLineItems()
            {
                UnitPrice = "100.00",
                DiscountRate = "0.013",
                Quantity = 2,
                UnitOfMeasure = "inch",
                DiscountAmount = "10",
                TaxAppliedAfterDiscount = "8",
                AmountIncludesTax = true,
                DiscountApplied = true,
                ProductName = "PName0",
                TaxRate = "0.082",
                TotalAmount = "1100",
                ProductSku = "testdl",
                ProductCode = "clothing",
                CommodityCode = "987654321012",
                TaxAmount = "20.00"
            };

            var lineItemsList = new List<V2paymentsidrefundsOrderInformationLineItems>
            {
                lineItemsObj
            };

            var v2PaymentsidrefundsOrderInformationObj = new V2paymentsidrefundsOrderInformation()
            {
                LineItems = lineItemsList
            };

            requestObj.OrderInformation = v2PaymentsidrefundsOrderInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5337974231586422201013/refunds",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new RefundApi(configurationSwagger);
                var result = apiInstance.RefundPayment(requestObj, "5337974231586422201013");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
