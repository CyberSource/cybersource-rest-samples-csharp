using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class PaymentNetworkTokenization
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC_123122";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            if (CaptureTrueForProcessPayment)
            {
                processingInformationCapture = true;
            }

            string processingInformationCommerceIndicator = "internet";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator
           );

            string paymentInformationTokenizedCardNumber = "4111111111111111";
            string paymentInformationTokenizedCardExpirationMonth = "12";
            string paymentInformationTokenizedCardExpirationYear = "2031";
            string paymentInformationTokenizedCardTransactionType = "1";
            Ptsv2paymentsPaymentInformationTokenizedCard paymentInformationTokenizedCard = new Ptsv2paymentsPaymentInformationTokenizedCard(
                Number: paymentInformationTokenizedCardNumber,
                ExpirationMonth: paymentInformationTokenizedCardExpirationMonth,
                ExpirationYear: paymentInformationTokenizedCardExpirationYear,
                TransactionType: paymentInformationTokenizedCardTransactionType
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                TokenizedCard: paymentInformationTokenizedCard
           );

            string orderInformationAmountDetailsTotalAmount = "100";
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

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            string consumerAuthenticationInformationCavv = "AAABCSIIAAAAAAACcwgAEMCoNh+=";
            string consumerAuthenticationInformationXid = "T1Y0OVcxMVJJdkI0WFlBcXptUzE=";
            Ptsv2paymentsConsumerAuthenticationInformation consumerAuthenticationInformation = new Ptsv2paymentsConsumerAuthenticationInformation(
                Cavv: consumerAuthenticationInformationCavv,
                Xid: consumerAuthenticationInformationXid
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                ConsumerAuthenticationInformation: consumerAuthenticationInformation
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
