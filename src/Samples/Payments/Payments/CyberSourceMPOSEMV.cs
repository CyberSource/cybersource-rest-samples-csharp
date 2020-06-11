using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class CyberSourceMPOSEMV
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;

        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_16";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            if (CaptureTrueForProcessPayment)
            {
                processingInformationCapture = true;
            }

            string processingInformationCommerceIndicator = "retail";
            string processingInformationPaymentSolution = "011";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator,
                PaymentSolution: processingInformationPaymentSolution
           );

            string paymentInformationFluidDataDescriptor = "EMV.PAYMENT.AnywhereCommerce.Walker";
            string paymentInformationFluidDataValue = "ewogICJkYXRhIiA6ICJOZmNwRURiK1dLdzBnQkpsaTRcL1hlWm1ITzdUSng0bnRoMnc2Mk9ITVJQK3hCRlFPdFE0WWpRcnY0RmFkOHh6VExqT2VFQm5iNHFzeGZMYTNyNXcxVEdXblFGQnNzMWtPYnA0XC95alNtVE1JSGVjbGc5OFROaEhNb0VRcjJkRkFqYVpBTFAxSlBsdVhKSVwvbTZKSmVwNGh3VHRWZE16Z2laSUhnaWFCYzNXZVd1ZnYzc1l0cGRaZDZYZENEUFdLeXFkYjBJdUtkdkpBPT0iLAogICJzaWduYXR1cmUiIDogIkFxck1pKzc0cm1GeVBKVE9HN3NuN2p5K1YxTlpBZUNJVE56TW01N1B5cmc9IiwKICAic2lnbmF0dXJlQWxnSW5mbyIgOiAiSE1BQ3dpdGhTSEEyNTYiLAogICJoZWFkZXIiIDogewogICAgInRyYW5zYWN0aW9uSWQiIDogIjE1MTU2MjI2NjIuMTcyMjIwIiwKICAgICJwdWJsaWNLZXlIYXNoIiA6ICJcLzdmdldqRVhMazJPRWpcL3Z5bk1jeEZvMmRWSTlpRXVoT2Nab0tHQnpGTmM9IiwKICAgICJhcHBsaWNhdGlvbkRhdGEiIDogIkN5YmVyU291cmNlLlZNcG9zS2l0IiwKICAgICJlcGhlbWVyYWxQdWJsaWNLZXkiIDogIk1Ga3dFd1lIS29aSXpqMENBUVlJS29aSXpqMERBUWNEUWdBRW1JN0tScnRNN2NNelk5Zmw2UWt2NEQzdE9jU0NYR1hoOFwvK2R4K2s5c1Zrbk05UFQrOXRqMzk2YWF6QjRcL0hYaWlLRW9DXC9jUzdoSzF6UFk3MVwvN0pUUT09IgogIH0sCiAgInZlcnNpb24iIDogIjEuMCIKfQ==";
            Ptsv2paymentsPaymentInformationFluidData paymentInformationFluidData = new Ptsv2paymentsPaymentInformationFluidData(
                Descriptor: paymentInformationFluidDataDescriptor,
                Value: paymentInformationFluidDataValue
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                FluidData: paymentInformationFluidData
           );

            string orderInformationAmountDetailsTotalAmount = "15.0";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToAddress2 = "Address 2";
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
                Address2: orderInformationBillToAddress2,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            int pointOfSaleInformationCatLevel = 1;
            string pointOfSaleInformationEntryMode = "contact";
            int pointOfSaleInformationTerminalCapability = 1;
            bool pointOfSaleInformationEmvFallback = true;
            int pointOfSaleInformationEmvFallbackCondition = 1;
            Ptsv2paymentsPointOfSaleInformationEmv pointOfSaleInformationEmv = new Ptsv2paymentsPointOfSaleInformationEmv(
                Fallback: pointOfSaleInformationEmvFallback,
                FallbackCondition: pointOfSaleInformationEmvFallbackCondition
           );

            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                CatLevel: pointOfSaleInformationCatLevel,
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability,
                Emv: pointOfSaleInformationEmv
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                PointOfSaleInformation: pointOfSaleInformation
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
