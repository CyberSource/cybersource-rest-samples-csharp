using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Risk_Management.CoreServices
{
    public class DmWithTravelInformation
    {
        public static RiskV1DecisionsPost201Response Run()
        {
            var requestObj = new CreateDecisionManagerCaseRequest();

            var clientReferenceInformation = new Riskv1decisionsClientReferenceInformation();

            clientReferenceInformation.Code = "54323007";
            requestObj.ClientReferenceInformation = clientReferenceInformation;

            var paymentInformation = new Riskv1decisionsPaymentInformation();

            var card = new Riskv1decisionsPaymentInformationCard();

            card.Number = "4444444444444448";
            card.ExpirationMonth = "12";
            card.ExpirationYear = "2020";
            paymentInformation.Card = card;

            requestObj.PaymentInformation = paymentInformation;

            var orderInformation = new Riskv1decisionsOrderInformation();

            var amountDetails = new Riskv1decisionsOrderInformationAmountDetails("USD");

            amountDetails.Currency = "USD";
            amountDetails.TotalAmount = "144.14";
            orderInformation.AmountDetails = amountDetails;

            var billTo = new Riskv1decisionsOrderInformationBillTo();

            billTo.Address1 = "96, powers street";
            billTo.AdministrativeArea = "NH";
            billTo.Country = "US";
            billTo.Locality = "Clearwater milford";
            billTo.FirstName = "James";
            billTo.LastName = "Smith";
            billTo.PhoneNumber = "7606160717";
            billTo.Email = "test@visa.com";
            billTo.PostalCode = "03055";
            orderInformation.BillTo = billTo;

            requestObj.OrderInformation = orderInformation;

            var travelInformation = new Riskv1decisionsTravelInformation();

            travelInformation.CompleteRoute = "SFO-JFK:JFK-BLR";
            travelInformation.DepartureTime = "2011-03-20 11:30pm GMT";
            travelInformation.JourneyType = "One way";
            var legs = new List<Riskv1decisionsTravelInformationLegs>();

            var legs0 = new Riskv1decisionsTravelInformationLegs();
            legs0.Origination = "SFO";
            legs0.Destination = "JFK";
            legs.Add(legs0);

            var legs1 = new Riskv1decisionsTravelInformationLegs();
            legs1.Origination = "JFK";
            legs1.Destination = "BLR";
            legs.Add(legs1);

            travelInformation.Legs = legs;

            requestObj.TravelInformation = travelInformation;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new DecisionManagerApi(clientConfig);

                var result = apiInstance.CreateDecisionManagerCase(requestObj);
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
