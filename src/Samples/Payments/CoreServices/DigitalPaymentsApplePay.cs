using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class DigitalPaymentsApplePay
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC_1231223";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            string processingInformationCommerceIndicator = "internet";
            string processingInformationPaymentSolution = "001";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator,
                PaymentSolution: processingInformationPaymentSolution
           );

            string paymentInformationTokenizedCardNumber = "4111111111111111";
            string paymentInformationTokenizedCardExpirationMonth = "12";
            string paymentInformationTokenizedCardExpirationYear = "2031";
            string paymentInformationTokenizedCardCryptogram = "AceY+igABPs3jdwNaDg3MAACAAA=";
            string paymentInformationTokenizedCardTransactionType = "1";
            Ptsv2paymentsPaymentInformationTokenizedCard paymentInformationTokenizedCard = new Ptsv2paymentsPaymentInformationTokenizedCard(
                Number: paymentInformationTokenizedCardNumber,
                ExpirationMonth: paymentInformationTokenizedCardExpirationMonth,
                ExpirationYear: paymentInformationTokenizedCardExpirationYear,
                Cryptogram: paymentInformationTokenizedCardCryptogram,
                TransactionType: paymentInformationTokenizedCardTransactionType
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                TokenizedCard: paymentInformationTokenizedCard
           );

            string orderInformationAmountDetailsTotalAmount = "10";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Deo";
            string orderInformationBillToAddress1 = "901 Metro Center Blvd";
            string orderInformationBillToLocality = "Foster City";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94404";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "6504327113";
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

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
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
