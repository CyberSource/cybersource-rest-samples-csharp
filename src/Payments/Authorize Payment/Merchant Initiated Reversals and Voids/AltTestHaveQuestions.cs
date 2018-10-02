using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Merchant_Initiated_Reversals_and_Voids
{
    public class AltTestHaveQuestions
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC50171_1"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "VDP",
                Address1 = "201 S. Division St.",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                AdministrativeArea = "MI",
                FirstName = "RTS",
                District = "MI",
                BuildingNumber = "123",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var recipientInformationObj = new V2paymentsRecipientInformation();

            // var v2PaymentsPaymentInformationCardObj = new V2paymentsPaymentInformationCard
            // {
            //     ExpirationYear = "2031",
            //     Number = "4111111111111111",
            //     ExpirationMonth = "12"
            // };
            // recipientInformationObj.Card = v2PaymentsPaymentInformationCardObj;
            requestObj.RecipientInformation = recipientInformationObj;

            // var reversalInformationObj = new ReversalInformation();

            // var v2PaymentsidreversalsReversalInformationAmountDetailsObj = new V2paymentsidreversalsReversalInformationAmountDetails();

            // v2PaymentsidreversalsReversalInformationAmountDetailsObj.TotalAmount = "3000.00";
            // reversalInformationObj.AmountDetails = v2paymentsOrderInformationAmountDetailsObj;

            // requestObj.ReversalInformation = reversalInformationObj;

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
