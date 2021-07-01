using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class DMWithBuyerInformation
    {
        public static RiskV1DecisionsPost201Response Run()
        {
            string clientReferenceInformationCode = "54323007";
            Riskv1decisionsClientReferenceInformation clientReferenceInformation = new Riskv1decisionsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCardNumber = "4444444444444448";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2020";
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
                BillTo: orderInformationBillTo
           );

            string buyerInformationHashedPassword = "";
            string buyerInformationDateOfBirth = "19980505";

            List<Ptsv2paymentsBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List<Ptsv2paymentsBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationType1 = "CPF";
            string buyerInformationPersonalIdentificationId1 = "1a23apwe98";
            buyerInformationPersonalIdentification.Add(new Ptsv2paymentsBuyerInformationPersonalIdentification(
                Type: buyerInformationPersonalIdentificationType1,
                Id: buyerInformationPersonalIdentificationId1
           ));

            Riskv1decisionsBuyerInformation buyerInformation = new Riskv1decisionsBuyerInformation(
                HashedPassword: buyerInformationHashedPassword,
                DateOfBirth: buyerInformationDateOfBirth,
                PersonalIdentification: buyerInformationPersonalIdentification
           );

            var requestObj = new CreateBundledDecisionManagerCaseRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                BuyerInformation: buyerInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DecisionManagerApi(clientConfig);
                RiskV1DecisionsPost201Response result = apiInstance.CreateBundledDecisionManagerCase(requestObj);
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
