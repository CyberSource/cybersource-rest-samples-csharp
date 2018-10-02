using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Capture_Payment.Simple_Capture
{
    public class ScBillAmtGreaterThanAuthAmt
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CapturePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "1234567890"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;
            /*
            var v2paymentsPointOfSaleInformationObj = new V2paymentsidcapturesPointOfSaleInformation();
            {
                CardPresent = "false",
                CatLevel = "6",
                TerminalCapability = "4"
            };

            requestObj.PointOfSaleInformation = v2paymentsPointOfSaleInformationObj;
            */
            var v2PaymentsOrderInformationObj = new V2paymentsidcapturesOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsidcapturesOrderInformationBillTo
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

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "100",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

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
