using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Risk_Management.CoreServices
{
    public class DmWithBuyerInformation
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

            var buyerInformation = new Riskv1decisionsBuyerInformation();

            buyerInformation.HashedPassword = "";
            buyerInformation.DateOfBirth = "1998-05-05";
            var personalIdentification = new List<Ptsv2paymentsBuyerInformationPersonalIdentification>();

            var personalIdentification0 = new Ptsv2paymentsBuyerInformationPersonalIdentification();
            personalIdentification0.Type = "CPF";
            personalIdentification0.Id = "1a23apwe98";
            personalIdentification.Add(personalIdentification0);

            requestObj.BuyerInformation = buyerInformation;

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
