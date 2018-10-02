using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Digital_Payments.AndroidPay
{
    public class AuthorizeAndroidPayCyberSourceDecryption
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC_MPOS_Paymentech_1"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                PaymentSolution = "006"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "VDP",
                Address1 = "201 S. Division St.",
                PostalCode = "48104-2201",
                FirstName = "RTS"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var v2PaymentsPaymentInformationFluidDataObj = new V2paymentsPaymentInformationFluidData
            {
                Value =
                    "ewoJInB1YmxpY0tleUhhc2giICAgIDogIlNKU1NSN0Q4VHZxbHBPWmcwMFhWY1pYclI1czJBUTJxYU8rK0VTVnl4clU9IiwKCSJ2ZXJzaW9uIjogIjEuMCIsCgkiZGF0YSIgOiAiZXdvSkltVnVZM0o1Y0hSbFpFMWxjM05oWjJVaU9pQWlSbFZrUjNWQlFWVlpRVWd2VXpreU1rczNXVE5QTm5VclpsWXJlbU5wUjBwamN6SkRPVVJ1Ykd0TlYyZzJZa2hVS3pCd2FsTTJjbkZJTDFoTWVYcGlSVTg1WWtsdkwyUmtUbTEzYVRGblRqbEVZV1Y2Y3pOdlpFNXVValZ0Ykd4MlIzWktNRVpYU0ZKeVRTOVRabVF6TlRZeVlqaFNObFpST1ZwS1ZUTmFNMXBDT0ZSWmFtdGpiWGhVTHpkSWQwaHdVWGgxUmpaT2JXZHNWMmwwVnk5VU0ya3dSVE5QV1dwUkswZGtWbTFZTVVOaVoxbHNlWHBRTVVOSWFrNXdUV3RxVUhvMGVrTlVibUpHTmxGc1pIWkxaVFJvYkhselpuZ3pPVzlwVEU5YVIxcG9SSGhVVDNwU2VXUXhWekl6VVQwOUlpd0tDU0psY0dobGJXVnlZV3hRZFdKc2FXTkxaWGtpT2lBaVRVWnJkMFYzV1VoTGIxcEplbW93UTBGUldVbExiMXBKZW1vd1JFRlJZMFJSWjBGRmJ6RnlUMnBGU2t4SUsxWk1VRGQwUkV4YVdHSnBia2xaWWtjeVYwOXZjMDlDZWs5TVMyVkRiMU5ZVm1KSk9XNTBjWFpHT1dKelRtRlhOWEJYUkRsbFdsUXZXSHBHZURoTGIwdEROVmhOYVRSblZXWkdRMUU5UFNJc0Nna2lkR0ZuSWpvZ0lrVkRkRFZwVW1kM1VscGxMM2hJWlRCSU1rMXJhRUpGTXpSM1dYVXllVFJKZG13ME5uUjRXSFlyVjFFOUlncDkiCn0="
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
