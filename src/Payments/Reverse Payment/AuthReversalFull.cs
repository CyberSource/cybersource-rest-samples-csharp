using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Reverse_Payment
{
    public class AuthReversalFull
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new AuthReversalRequest();

            var clientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation("TC50171_1");

            // var amount = new V2paymentsidreversalsOrderInformationLineItems();
            // amount.Currency = "USD";
            // var amountDetailsObj = new List<V2paymentsidreversalsOrderInformationLineItems> { amount };
            // var orderInformationObj = new V2paymentsidreversalsOrderInformation(amountDetailsObj);

            var amountDetailsObj = new V2paymentsidreversalsReversalInformationAmountDetails
            {
                TotalAmount = "100.00"
            };

            var reversalInformationObj = new V2paymentsidreversalsReversalInformation
            {
                AmountDetails = amountDetailsObj
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;
            requestObj.ReversalInformation = reversalInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5334411871436531903527/reversals",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new ReversalApi(configurationSwagger);
                var result = apiInstance.AuthReversal("5334411871436531903527", requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}