using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Network_Tokenization
{
    public class CyberSourcePaymentTokenization
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC_MPOS_Paymentech_3"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                CommerceIndicator = "internet"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                FirstName = "RTS",
                LastName = "VDP",
                PhoneNumber = "6504327113",
                Address1 = "901 Metro Center Blvd",
                PostalCode = "94404",
                Locality = "Foster City",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "2719",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var tokenizedCardObj = new V2paymentsPaymentInformationTokenizedCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                ExpirationMonth = "12",
                TransactionType = "1"
            };

            v2PaymentsPaymentInformationObj.TokenizedCard = tokenizedCardObj;

            var v2PaymentsPaymentInformationFluidDataObj = new V2paymentsPaymentInformationFluidData
            {
                Value =
                    "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"
            };

            v2PaymentsPaymentInformationObj.FluidData = v2PaymentsPaymentInformationFluidDataObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;



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
