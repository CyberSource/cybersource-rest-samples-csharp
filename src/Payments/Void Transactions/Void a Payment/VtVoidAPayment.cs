using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Void_Transactions.Void_a_Payment
{
    public class VtVoidAPayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new VoidPaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation
            {
                Code = "1234567890"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            /*
            var v2paymentsPointOfSaleInformationObj = new V2paymentsPointOfSaleInformation();

            v2paymentsPointOfSaleInformationObj.CardPresent = "false";
            v2paymentsPointOfSaleInformationObj.CatLevel = "6";
            v2paymentsPointOfSaleInformationObj.TerminalCapability = "4";
            requestObj.PointOfSaleInformation = v2paymentsPointOfSaleInformationObj;

            var v2paymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2paymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo();

            v2paymentsOrderInformationBillToObj.Country = "US";
            v2paymentsOrderInformationBillToObj.FirstName = "RTS";
            v2paymentsOrderInformationBillToObj.LastName = "VDP";
            v2paymentsOrderInformationBillToObj.Address1 = "901 Metro Center Blvd";
            v2paymentsOrderInformationBillToObj.PostalCode = "40500";
            v2paymentsOrderInformationBillToObj.Locality = "Foster City";
            v2paymentsOrderInformationBillToObj.AdministrativeArea = "CA";
            v2paymentsOrderInformationBillToObj.Email = "test@cybs.com";
            v2paymentsOrderInformationObj.BillTo = v2paymentsOrderInformationBillToObj;

            var v2paymentsOrderInformationAmountDetailsObj = new V2paymentsOrderInformationAmountDetails();

            v2paymentsOrderInformationAmountDetailsObj.TotalAmount = "100";
            v2paymentsOrderInformationAmountDetailsObj.Currency = "USD";
            v2paymentsOrderInformationObj.AmountDetails = v2paymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2paymentsOrderInformationObj;
            */

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5335461889256917903529/voids",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new VoidApi(configurationSwagger);
                var result = apiInstance.VoidPayment(requestObj, "5335461889256917903529");
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
