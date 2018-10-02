using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.All_Services
{
    public class CapturePayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CapturePaymentRequest();

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "1234567890"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var pointOfSaleInformationObj = new V2paymentsidcapturesPointOfSaleInformation();

            // pointOfSaleInformationObj.CardPresent = "false";
            // pointOfSaleInformationObj.CatLevel = "6";
            // pointOfSaleInformationObj.TerminalCapability = "4";
            // requestObj.PointOfSaleInformation = pointOfSaleInformationObj;

            var orderInformationObj = new V2paymentsidcapturesOrderInformation();

            var billToObj = new V2paymentsidcapturesOrderInformationBillTo
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

            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "100",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5344021876376240704005/captures",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new CaptureApi(configurationSwagger);
                var result = apiInstance.CapturePayment(requestObj, "5344021876376240704005");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
