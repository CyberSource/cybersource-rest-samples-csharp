using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class PaymentWithFlexToken
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "RTS";
            string orderInformationBillToLastName = "VDP";
            string orderInformationBillToAddress1 = "201 S. Division St.";
            string orderInformationBillToLocality = "Ann Arbor";
            string orderInformationBillToAdministrativeArea = "MI";
            string orderInformationBillToPostalCode = "48104-2201";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToDistrict = "MI";
            string orderInformationBillToBuildingNumber = "123";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "999999999";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                District: orderInformationBillToDistrict,
                BuildingNumber: orderInformationBillToBuildingNumber,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            string tokenInformationTransientTokenJwt = "eyJraWQiOiIwN0JwSE9abkhJM3c3UVAycmhNZkhuWE9XQlhwa1ZHTiIsImFsZyI6IlJTMjU2In0.eyJkYXRhIjp7ImV4cGlyYXRpb25ZZWFyIjoiMjAyMCIsIm51bWJlciI6IjQxMTExMVhYWFhYWDExMTEiLCJleHBpcmF0aW9uTW9udGgiOiIxMCIsInR5cGUiOiIwMDEifSwiaXNzIjoiRmxleC8wNyIsImV4cCI6MTU5MTc0NjAyNCwidHlwZSI6Im1mLTAuMTEuMCIsImlhdCI6MTU5MTc0NTEyNCwianRpIjoiMUMzWjdUTkpaVjI4OVM5MTdQM0JHSFM1T0ZQNFNBRERCUUtKMFFKMzMzOEhRR0MwWTg0QjVFRTAxREU4NEZDQiJ9.cfwzUMJf115K2T9-wE_A_k2jZptXlovls8-fKY0muO8YzGatE5fu9r6aC4q7n0YOvEU6G7XdH4ASG32mWnYu-kKlqN4IY_cquRJeUvV89ZPZ5WTttyrgVH17LSTE2EvwMawKNYnjh0lJwqYJ51cLnJiVlyqTdEAv3DJ3vInXP1YeQjLX5_vF-OWEuZfJxahHfUdsjeGhGaaOGVMUZJSkzpTu9zDLTvpb1px3WGGPu8FcHoxrcCGGpcKk456AZgYMBSHNjr-pPkRr3Dnd7XgNF6shfzIPbcXeWDYPTpS4PNY8ZsWKx8nFQIeROMWCSxIZOmu3Wt71KN9iK6DfOPro7w";
            Ptsv2paymentsTokenInformation tokenInformation = new Ptsv2paymentsTokenInformation(
                TransientTokenJwt: tokenInformationTransientTokenJwt
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                TokenInformation: tokenInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
