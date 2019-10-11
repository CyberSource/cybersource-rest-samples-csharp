using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Decision_Manager
{
    public class DMWithTravelInformation
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

            string travelInformationCompleteRoute = "SFO-JFK:JFK-BLR";
            string travelInformationDepartureTime = "2011-03-20 11:30pm GMT";
            string travelInformationJourneyType = "One way";

            List <Riskv1decisionsTravelInformationLegs> travelInformationLegs = new List <Riskv1decisionsTravelInformationLegs>();
            string travelInformationLegsOrigination1 = "SFO";
            string travelInformationLegsDestination1 = "JFK";
            travelInformationLegs.Add(new Riskv1decisionsTravelInformationLegs(
                Origination: travelInformationLegsOrigination1,
                Destination: travelInformationLegsDestination1
           ));

            string travelInformationLegsOrigination2 = "JFK";
            string travelInformationLegsDestination2 = "BLR";
            travelInformationLegs.Add(new Riskv1decisionsTravelInformationLegs(
                Origination: travelInformationLegsOrigination2,
                Destination: travelInformationLegsDestination2
           ));

            Riskv1decisionsTravelInformation travelInformation = new Riskv1decisionsTravelInformation(
                CompleteRoute: travelInformationCompleteRoute,
                DepartureTime: travelInformationDepartureTime,
                JourneyType: travelInformationJourneyType,
                Legs: travelInformationLegs
           );

            var requestObj = new CreateDecisionManagerCaseRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                TravelInformation: travelInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DecisionManagerApi(clientConfig);
                RiskV1DecisionsPost201Response result = apiInstance.CreateDecisionManagerCase(requestObj);
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
