using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication.CoreServices
{
    public class EnrollWithTravelInformation
    {
        public static RiskV1AuthenticationsPost201Response Run()
        {
            var requestObj = new CheckPayerAuthEnrollmentRequest();

            var clientReferenceInformation = new Riskv1authenticationsClientReferenceInformation(Code: "cybs_test");

            requestObj.ClientReferenceInformation = clientReferenceInformation;

            var orderInformation = new Riskv1authenticationsOrderInformation();

            var amountDetails = new Riskv1decisionsOrderInformationAmountDetails(Currency: "USD", TotalAmount: "10.99");

            orderInformation.AmountDetails = amountDetails;

            var billTo = new Riskv1authenticationsOrderInformationBillTo
            (
                Address1: "1 Market St",
                Address2: "Address 2",
                AdministrativeArea: "CA",
                Country: "US",
                Locality: "san francisco",
                FirstName: "John",
                LastName: "Doe",
                PhoneNumber: "4158880000",
                Email: "test@cybs.com",
                PostalCode: "94105"
            );
            orderInformation.BillTo = billTo;

            requestObj.OrderInformation = orderInformation;

            var paymentInformation = new Riskv1authenticationsPaymentInformation();

            var card = new Riskv1authenticationsPaymentInformationCard
            (
                Type: "001",
                ExpirationMonth: "12",
                ExpirationYear: "2025",
                Number: "5200340000000015"
            );
            paymentInformation.Card = card;

            requestObj.PaymentInformation = paymentInformation;

            var buyerInformation = new Riskv1authenticationsBuyerInformation(MobilePhone: 1245789632);

            requestObj.BuyerInformation = buyerInformation;

            var consumerAuthenticationInformation = new Riskv1authenticationsConsumerAuthenticationInformation(TransactionMode: "MOTO", Mcc: string.Empty, ReferenceId: string.Empty);

            requestObj.ConsumerAuthenticationInformation = consumerAuthenticationInformation;

            var travelInformation = new Riskv1authenticationsTravelInformation();

            var legs = new List<Riskv1authenticationsTravelInformationLegs>();

            var legs0 = new Riskv1authenticationsTravelInformationLegs();
            legs0.Destination = "DEFGH";
            legs0.CarrierCode = "UA";
            legs0.DepartureDate = "2019-01-01";
            legs.Add(legs0);

            var legs1 = new Riskv1authenticationsTravelInformationLegs();
            legs1.Destination = "RESD";
            legs1.CarrierCode = "AS";
            legs1.DepartureDate = "2019-02-21";
            legs.Add(legs1);

            travelInformation.NumberOfPassengers = 2;
            var passengers = new List<Riskv1authenticationsTravelInformationPassengers>();

            var passengers0 = new Riskv1authenticationsTravelInformationPassengers();
            passengers0.FirstName = "Raj";
            passengers0.LastName = "Charles";
            passengers.Add(passengers0);

            var passengers1 = new Riskv1authenticationsTravelInformationPassengers();
            passengers1.FirstName = "Potter";
            passengers1.LastName = "Suhember";
            passengers.Add(passengers1);

            requestObj.TravelInformation = travelInformation;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PayerAuthenticationApi(clientConfig);

                var result = apiInstance.CheckPayerAuthEnrollment(requestObj);
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
