using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Digital_Payments.SamSung_Pay
{
    public class AuthorizeSamsungPayCyberSourceDecryption
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
                CommerceIndicator = "vbv",
                PaymentSolution = "008"
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
                    "ewoJInB1YmxpY0tleUhhc2giOiAiaTRYell5MFRnNnkvaEUwV2RrK0dwOHV4aml4U3I0US91MUxNOVd0VTl2az0iLAoJInZlcnNpb24iOiAiMTAwIiwKCSJkYXRhIjogIlpYZHZTa2x0Um5OYWVVazJTVU5LVTFVd1JYaFllbFZwVEVGdlNrbHRWblZaZVVrMlNVTktRazFxVlRKU01FNU9TV2wzUzBOVFNuSmhWMUZwVDJsQmFXRlVVbGxsYkd3MVRVWlNiazV1YTNaaFJWVjNWakpTY2tzd1pIZFBTRlkwWVcxc05GVXpTVEJWVXpreFRWVjRUazlXWkRCV1ZHd3lZWG93YVV4QmIwcEpibEkxWTBOSk5rbERTa3RVTVU1R1NXbDNTME5UU21waFIwWjFZbTFXYzFVeVZtcGtXRXB3WkVoc1JHSXlOVEJhV0dnd1NXcHZaMGxzU2xSUlZqbFJVekJyYVVOdU1DNUdURGxEYTJScFFtOHlTSEExWDJ0Qk5WOUJNM2hJUjFCaFQwZDBSMmRWVVRoWk5UY3dNVjlzUmxSU1IxbFlNRWRpYlV4d05GVnBhM1JSV1Voa09FaHZUR3RrVVUxRFUwVjJNRGhXU0daZlJVUmtSaloyTW5rMmJURkJSRmhCWjAxeE9FaHlNVjlOT1daalpXWXhTMGgzVmpCVlNYSlRlRWN4TUZneVUwMTJVa2xmTURKcU9FVjJVV2gyZWt4dVMzRXhiRWgxTUUxMmVEZHdhV1IzYkU4NVJVdG5iRmRTY2tGTlh5MVlRMmczVW1WaE4wWmxaVU16VW00d1dqQnRUMFpZVEhaUVdESkxlWEJ5ZDFCemFHOWpZemxhTW5rNFJYVmlSVzVaT1Zka1pqazJNRUZtVTJwTGIyOHRXRlphVGxoNk5WVlZiSFZoWW5WdVlrRkNlSEJ1VWpsTlMzZzRaMnhoWjBwT1RHcFdOMjB4YzFCT1RrMVBaa1YzT1hoU1V6RjBkWE5sV2sxNFdURnRiRFJDVVVSb1IwWTROa1ZXU0hkUmFXbGpWRGhDYmxkVVVFRlBZVk5uWVVwWk1tVndjMTluVDI5aVptY3VZazFaZVdKSE5EVlFRblJNVG14TVUxOUxiRzVOUVM1Mk1tUmZkVmN5T0c5T1JqUnVUV2xPWTBOeVdWSktlSEJ6YlhJd09XZHRiM0ZSUkZkVk5FRldTMFJ6Wm5VNVltdENTRVJuTnpGclNHaGtNMDV6UTJselpXSmlia2swWVUxWE1sTkxNV054UzNCWVgwaFBNRGswU0hoeVZHeEtUV3gwY21kS2VIWjJMWGd4VVU5eVlXNUNTMnRxY0hsNlpVcDNabWRXWXkxblJ6SktPV2d4U25jMFdIRm1Nbk5ZZFZwbWQzSnJSM0pZTjAxcWFXTnRhVWxuZERGU1lURjZkRGRUYUVvemRucFlSRm81V2paTFUyaDFZWEF6TkZFd05VcERaRUpVTUhseFdqZHVaM2hwWjJ4c2EzbDFWazFRWXpkbWRpMUJkMWhzYkRoc2FtUm9la3BsYmxKdFR6ZEhVRnBtY0dsRlVUWkNTVjl2WWpWTmJERllTRlZHWXpSUFRXZG5TR3hOUW0xWFRqWkxhVVJFUldsUlIyaERaVlZpWW01MmJXTXVMVlZhVUVoME4zUkVPVGRmWVdONFgyRk5SakptUVE9PSIKfQ=="
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
