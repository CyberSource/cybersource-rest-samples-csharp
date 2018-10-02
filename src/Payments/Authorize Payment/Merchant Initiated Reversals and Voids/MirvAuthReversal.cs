using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Merchant_Initiated_Reversals_and_Voids
{
    public class MirvAuthReversal
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new AuthReversalRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsidreversalsClientReferenceInformation
            {
                Code = "TC50171_1"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            // var v2paymentsOrderInformationObj = new V2paymentsidreversalsOrderInformation();

            // var amountDetailsObj = new V2paymentsidreversalsOrderInformationAmountDetails();

            // amountDetailsObj.Currency = "USD";
            // v2paymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            // requestObj.OrderInformation = v2paymentsOrderInformationObj;

            var reversalInformationObj = new V2paymentsidreversalsReversalInformation();

            var amountDetailsObj = new V2paymentsidreversalsReversalInformationAmountDetails
            {
                TotalAmount = "3000.00"
            };

            reversalInformationObj.AmountDetails = amountDetailsObj;

            requestObj.ReversalInformation = reversalInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments/5305395916686582801541/reversals",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new ReversalApi(configurationSwagger);
                var result = apiInstance.AuthReversal("5305395916686582801541", requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
