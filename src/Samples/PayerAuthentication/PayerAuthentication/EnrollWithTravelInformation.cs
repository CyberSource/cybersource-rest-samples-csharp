using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class EnrollWithTravelInformation
    {
        public static RiskV1AuthenticationsPost201Response Run()
        {
            string clientReferenceInformationCode = "cybs_test";
            Riskv1authenticationsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsTotalAmount = "10.99";
            Riskv1authenticationsOrderInformationAmountDetails orderInformationAmountDetails = new Riskv1authenticationsOrderInformationAmountDetails(
                Currency: orderInformationAmountDetailsCurrency,
                TotalAmount: orderInformationAmountDetailsTotalAmount
           );

            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToAddress2 = "Address 2";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToLocality = "san francisco";
            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToPhoneNumber = "4158880000";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPostalCode = "94105";
            Riskv1authenticationsOrderInformationBillTo orderInformationBillTo = new Riskv1authenticationsOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                Country: orderInformationBillToCountry,
                Locality: orderInformationBillToLocality,
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                PhoneNumber: orderInformationBillToPhoneNumber,
                Email: orderInformationBillToEmail,
                PostalCode: orderInformationBillToPostalCode
           );

            Riskv1authenticationsOrderInformation orderInformation = new Riskv1authenticationsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            string paymentInformationCardType = "002";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            string paymentInformationCardNumber = "5200340000000015";
            Riskv1authenticationsPaymentInformationCard paymentInformationCard = new Riskv1authenticationsPaymentInformationCard(
                Type: paymentInformationCardType,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Number: paymentInformationCardNumber
           );

            Riskv1authenticationsPaymentInformation paymentInformation = new Riskv1authenticationsPaymentInformation(
                Card: paymentInformationCard
           );

            int buyerInformationMobilePhone = 1245789632;
            Riskv1authenticationsBuyerInformation buyerInformation = new Riskv1authenticationsBuyerInformation(
                MobilePhone: buyerInformationMobilePhone
           );

            string consumerAuthenticationInformationTransactionMode = "MOTO";
            Riskv1authenticationsConsumerAuthenticationInformation consumerAuthenticationInformation = new Riskv1authenticationsConsumerAuthenticationInformation(
                TransactionMode: consumerAuthenticationInformationTransactionMode
           );


            List <Riskv1authenticationsTravelInformationLegs> travelInformationLegs = new List <Riskv1authenticationsTravelInformationLegs>();
            string travelInformationLegsDestination1 = "DEFGH";
            string travelInformationLegsCarrierCode1 = "UA";
            string travelInformationLegsDepartureDate1 = "2019-01-01";
            travelInformationLegs.Add(new Riskv1authenticationsTravelInformationLegs(
                Destination: travelInformationLegsDestination1,
                CarrierCode: travelInformationLegsCarrierCode1,
                DepartureDate: travelInformationLegsDepartureDate1
           ));

            string travelInformationLegsDestination2 = "RESD";
            string travelInformationLegsCarrierCode2 = "AS";
            string travelInformationLegsDepartureDate2 = "2019-02-21";
            travelInformationLegs.Add(new Riskv1authenticationsTravelInformationLegs(
                Destination: travelInformationLegsDestination2,
                CarrierCode: travelInformationLegsCarrierCode2,
                DepartureDate: travelInformationLegsDepartureDate2
           ));

            int travelInformationNumberOfPassengers = 2;

            List <Riskv1authenticationsTravelInformationPassengers> travelInformationPassengers = new List <Riskv1authenticationsTravelInformationPassengers>();
            string travelInformationPassengersFirstName1 = "Raj";
            string travelInformationPassengersLastName1 = "Charles";
            travelInformationPassengers.Add(new Riskv1authenticationsTravelInformationPassengers(
                FirstName: travelInformationPassengersFirstName1,
                LastName: travelInformationPassengersLastName1
           ));

            string travelInformationPassengersFirstName2 = "Potter";
            string travelInformationPassengersLastName2 = "Suhember";
            travelInformationPassengers.Add(new Riskv1authenticationsTravelInformationPassengers(
                FirstName: travelInformationPassengersFirstName2,
                LastName: travelInformationPassengersLastName2
           ));

            Riskv1authenticationsTravelInformation travelInformation = new Riskv1authenticationsTravelInformation(
                Legs: travelInformationLegs,
                NumberOfPassengers: travelInformationNumberOfPassengers,
                Passengers: travelInformationPassengers
           );

            var requestObj = new CheckPayerAuthEnrollmentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                PaymentInformation: paymentInformation,
                BuyerInformation: buyerInformation,
                ConsumerAuthenticationInformation: consumerAuthenticationInformation,
                TravelInformation: travelInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationsPost201Response result = apiInstance.CheckPayerAuthEnrollment(requestObj);
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
