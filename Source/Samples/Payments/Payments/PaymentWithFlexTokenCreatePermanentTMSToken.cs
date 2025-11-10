using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class PaymentWithFlexTokenCreatePermanentTMSToken
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );


            List<string> processingInformationActionList = new List<string>();
            processingInformationActionList.Add("TOKEN_CREATE");

            List<string> processingInformationActionTokenTypes = new List<string>();
            processingInformationActionTokenTypes.Add("customer");
            processingInformationActionTokenTypes.Add("paymentInstrument");
            processingInformationActionTokenTypes.Add("shippingAddress");
            bool processingInformationCapture = false;
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                ActionList: processingInformationActionList,
                ActionTokenTypes: processingInformationActionTokenTypes,
                Capture: processingInformationCapture
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToLocality = "san francisco";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94105";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "4158880000";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            string orderInformationShipToFirstName = "John";
            string orderInformationShipToLastName = "Doe";
            string orderInformationShipToAddress1 = "1 Market St";
            string orderInformationShipToLocality = "san francisco";
            string orderInformationShipToAdministrativeArea = "CA";
            string orderInformationShipToPostalCode = "94105";
            string orderInformationShipToCountry = "US";
            Ptsv2paymentsOrderInformationShipTo orderInformationShipTo = new Ptsv2paymentsOrderInformationShipTo(
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName,
                Address1: orderInformationShipToAddress1,
                Locality: orderInformationShipToLocality,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                PostalCode: orderInformationShipToPostalCode,
                Country: orderInformationShipToCountry
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo
           );

            string tokenInformationTransientTokenJwt = "eyJraWQiOiIwOHAwWWVyTTBJSnpvYlpMMENyalVsRnQ4QXlIdXc4TSIsImFsZyI6IlJTMjU2In0.eyJkYXRhIjp7ImV4cGlyYXRpb25ZZWFyIjoiMjAyMyIsIm51bWJlciI6IjQxMTExMVhYWFhYWDExMTEiLCJleHBpcmF0aW9uTW9udGgiOiIwNyIsInR5cGUiOiIwMDEifSwiaXNzIjoiRmxleC8wOCIsImV4cCI6MTU5OTU2MDU3OSwidHlwZSI6Im1mLTAuMTEuMCIsImlhdCI6MTU5OTU1OTY3OSwianRpIjoiMUUyWjRMNjYxMENPSExHUUIxMlBXQk5OUjE1WFUwU1ROTTQ5UlA5WlJaUEtBVE1NOVo5UzVGNTc1QjgzNEFDOCJ9.Va9-Rf3nBtxHXVvb1M-mQqzOa86Uj5wY3qejFmYmMiSjMOSF_DpNepjOYat-8WqdacmhUemtwQfOtDEVDpd6X3YpBNydZ4dzVt3baq2Z1KAH1lEJxyvAyHX77tnO-wzfZrQm-HH-qtrGmt6ZvuNknvYPxwPcqnOryGaIQE70znBK6GVf3vgdE0xedxAQWl97ZfpZKafVjCvtGIMuJ0QdtrqM0OmtkoDKrqmXGzKlfSbpEep_yaDdpRkX_NdOgiVomRb3P6nqkT1OO0Czzu4HyxaMfVyCgGUAHd_SjXrwqM2vuchE4Scg1DicjWAJxXb_tZoAuUU0EN8HwVnrHiFAiQ";
            Ptsv2paymentsTokenInformation tokenInformation = new Ptsv2paymentsTokenInformation(
                TransientTokenJwt: tokenInformationTransientTokenJwt
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
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
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
