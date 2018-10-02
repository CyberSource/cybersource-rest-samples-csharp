using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.All_Services
{
    public class VoidAPayment
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new VoidPaymentRequest();

            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation
            {
                Code = "1234567890"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            /*
            var pointOfSaleInformationObj = new PointOfSaleInformation();

            pointOfSaleInformationObj.CardPresent = "false";
            pointOfSaleInformationObj.CatLevel = "6";
            pointOfSaleInformationObj.TerminalCapability = "4";
            requestObj.PointOfSaleInformation = pointOfSaleInformationObj;

            var orderInformationObj = new OrderInformation();

            var billToObj = new BillTo();

            billToObj.Country = "US";
            billToObj.FirstName = "RTS";
            billToObj.LastName = "VDP";
            billToObj.Address1 = "901 Metro Center Blvd";
            billToObj.PostalCode = "40500";
            billToObj.Locality = "Foster City";
            billToObj.AdministrativeArea = "CA";
            billToObj.Email = "test@cybs.com";
            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new AmountDetails();

            amountDetailsObj.TotalAmount = "100";
            amountDetailsObj.Currency = "USD";
            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;
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
