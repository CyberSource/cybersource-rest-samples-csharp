using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.Digital_Payments.Google_Pay
{
    public class AuthorizeGooglePayCyberSourceDecryption
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "33557799"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation
            {
                PaymentSolution = "012"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "TEST",
                Address1 = "201 S. Division St.",
                PostalCode = "48104-2201",
                FirstName = "CYBS"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "115.00",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var v2PaymentsPaymentInformationFluidDataObj = new V2paymentsPaymentInformationFluidData
            {
                Value =
                    "eyJzaWduYXR1cmUiOiJNRVVDSVFEaFR4aEhxd1k4cFhCOWhwWXhhU0s1akZnc3FwRzJFMXJYNzdRWHNzSzh0QUlnVUJ2WVlBSS9ibkJTOFQvVGZ4bm0yQUY5ODFNdjV5MHBIeUdleE01ZE1Ka1x1MDAzZCIsInByb3RvY29sVmVyc2lvbiI6IkVDdjEiLCJzaWduZWRNZXNzYWdlIjoie1wiZW5jcnlwdGVkTWVzc2FnZVwiOlwib2R5VUdHQTdCK2JsbGV0WWNKYlM0M0FRVUZRSnBXRUZDTjRVdVVFeFE1TFgwXC9YY0x3S0VsWGNCOTVuTW5tUE85bE0yS0dwMTNGWXNMNzY4Y2NDekFqQkdMWUYrZnVnY0pUY3ZrclVoY05TeVhyN2h3ZjEyQkVzcndlcUpNNkk3VnM1bGZyUEF1a1JKZUxEUUc0RnhtVExXNDlReVA4dklaQyt0ejJjK1ozem96ekk1b0I5akU4ZkEyZG9sRmExM0N1NmdYcWRLSFwvSUhSaDdVbmlMVXVUeSswRzVGUVYycHdTVDJ1QlNOTmtaaGI4V1lKREhieEJqejBVZWJWUCtPYm1UNWNjOEFLVTVkZ0hSZGZyNEdLcEVaNEVCekI5MEJQeExxWUhwb3ByaUo2bGJGZ0ZWc1FRNlwvOEhCcVE3SW1JTUg1eTdHOHA4cUFGa1duQjc4WmNMMEZoNUJqWG9qa3hHb0ZwMmdqQXNyaGh0dEhBRmJlM1dRQnVQa3dKdTA5XC82XC9NeUpwQ1NycE1IRm91RlwvZGowU1lqUSt4STA5N2xDSFplYzdqUXJBaElTTFdaOURaa3VNdkdLUFdwdTBDS24yWHFUWFE9XCIsXCJlcGhlbWVyYWxQdWJsaWNLZXlcIjpcIk1Ga3dFd1lIS29aSXpqMENBUVlJS29aSXpqMERBUWNEUWdBRW5uNHlqeTBONnhsWE84XC84ajdcLzRqdm1MSkNZQXFnWEx3UDFGaGp1VGdJTTlvQ3RQaWpaZkk5c28yUUVPczJablZwM0QwZGwzSllJRFZlKzM5NktrQVE9PVwiLFwidGFnXCI6XCJEUnBjYytZUTMzUk5nc1RjeHp0bkpiTUpuaXJiVTVEVzNkU3RqZmhGaXdjPVwifSJ9"
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
