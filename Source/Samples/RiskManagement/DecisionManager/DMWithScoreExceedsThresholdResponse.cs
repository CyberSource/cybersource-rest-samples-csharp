using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class DMWithScoreExceedsThresholdResponse
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1DecisionsPost201Response Run()
        {
            string clientReferenceInformationCode = "54323007";
            Riskv1decisionsClientReferenceInformation clientReferenceInformation = new Riskv1decisionsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCardNumber = "4444444444444448";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            Riskv1decisionsPaymentInformationCard paymentInformationCard = new Riskv1decisionsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            Riskv1decisionsPaymentInformation paymentInformation = new Riskv1decisionsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsTotalAmount = "144.14";
            Riskv1decisionsOrderInformationAmountDetails orderInformationAmountDetails = new Riskv1decisionsOrderInformationAmountDetails(
                Currency: orderInformationAmountDetailsCurrency,
                TotalAmount: orderInformationAmountDetailsTotalAmount
           );

            string orderInformationShipToAddress1 = "96, powers street";
            string orderInformationShipToAddress2 = "";
            string orderInformationShipToAdministrativeArea = "KA";
            string orderInformationShipToCountry = "IN";
            string orderInformationShipToLocality = "Clearwater milford";
            string orderInformationShipToFirstName = "James";
            string orderInformationShipToLastName = "Smith";
            string orderInformationShipToPhoneNumber = "7606160717";
            string orderInformationShipToPostalCode = "560056";
            Riskv1decisionsOrderInformationShipTo orderInformationShipTo = new Riskv1decisionsOrderInformationShipTo(
                Address1: orderInformationShipToAddress1,
                Address2: orderInformationShipToAddress2,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                Country: orderInformationShipToCountry,
                Locality: orderInformationShipToLocality,
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName,
                PhoneNumber: orderInformationShipToPhoneNumber,
                PostalCode: orderInformationShipToPostalCode
           );

            string orderInformationBillToAddress1 = "96, powers street";
            string orderInformationBillToAdministrativeArea = "NH";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "Clearwater milford";
            string orderInformationBillToFirstName = "James";
            string orderInformationBillToLastName = "Smith";
            string orderInformationBillToPhoneNumber = "7606160717";
            string orderInformationBillToEmail = "test@visa.com";
            string orderInformationBillToPostalCode = "03055";
            Riskv1decisionsOrderInformationBillTo orderInformationBillTo = new Riskv1decisionsOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                PhoneNumber: orderInformationBillToPhoneNumber,
                Email: orderInformationBillToEmail,
                PostalCode: orderInformationBillToPostalCode
           );

            Riskv1decisionsOrderInformation orderInformation = new Riskv1decisionsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                ShipTo: orderInformationShipTo,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreateBundledDecisionManagerCaseRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DecisionManagerApi(clientConfig);
                RiskV1DecisionsPost201Response result = apiInstance.CreateBundledDecisionManagerCase(requestObj);
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
