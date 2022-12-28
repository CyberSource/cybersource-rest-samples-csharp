using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.AzureIntermediateTesting
{
    public class AzureIntermediateTesting
    {
        public static PtsV2CreditsPost201Response Run()
        {
            string clientReferenceInformationCode = "12345678";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "03";
            string paymentInformationCardExpirationYear = "2031";
            string paymentInformationCardType = "001";
            Ptsv2paymentsidrefundsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsidrefundsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Type: paymentInformationCardType
           );

            Ptsv2paymentsidrefundsPaymentInformation paymentInformation = new Ptsv2paymentsidrefundsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsTotalAmount = "200";
            string orderInformationAmountDetailsCurrency = "usd";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Deo";
            string orderInformationBillToAddress1 = "900 Metro Center Blvd";
            string orderInformationBillToLocality = "Foster City";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "48104-2201";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "9321499232";
            Ptsv2paymentsidcapturesOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsidcapturesOrderInformationBillTo(
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

            Ptsv2paymentsidrefundsOrderInformation orderInformation = new Ptsv2paymentsidrefundsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreateCreditRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                //adding additional headers for azure host
                Dictionary<string, string> additionalHeaders = new Dictionary<string, string>();
                additionalHeaders.Add("Ocp-Apim-Subscription-Key", "=fchgfchgvjhvjh5536hg");
                additionalHeaders.Add("Ocp-Apim-Trace", "dfgcjgvjkhbkjkjhnkjvjgchdxh");

                var configDictionary = new Configuration().GetIntermediateConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(defaultHeader: additionalHeaders, merchConfigDictObj: configDictionary);

                var apiInstance = new CreditApi(clientConfig);
                PtsV2CreditsPost201Response result = apiInstance.CreateCredit(requestObj);
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
