using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication.CoreServices
{
    public class ValidateAuthenticationResults
    {
        public static RiskV1AuthenticationResultsPost201Response Run()
        {
            var requestObj = new Request();

            var clientReferenceInformation = new Riskv1authenticationsClientReferenceInformation(Code: "pavalidatecheck");

            requestObj.ClientReferenceInformation = clientReferenceInformation;

            var orderInformation = new Riskv1authenticationresultsOrderInformation();

            var amountDetails = new Riskv1decisionsOrderInformationAmountDetails(Currency: "USD", TotalAmount: "200.00");

            orderInformation.AmountDetails = amountDetails;

            var lineItems = new List<Riskv1authenticationresultsOrderInformationLineItems>();

            var lineItems0 = new Riskv1authenticationresultsOrderInformationLineItems
            (
                UnitPrice: "10",
                Quantity: 2,
                TaxAmount: "32.40"
            );

            lineItems.Add(lineItems0);

            requestObj.OrderInformation = orderInformation;

            var paymentInformation = new Riskv1authenticationresultsPaymentInformation();

            var card = new Riskv1authenticationresultsPaymentInformationCard
            (
                Type: "002",
                ExpirationMonth: "12",
                ExpirationYear: "2025",
                Number: "5200000000000007"
            );

            paymentInformation.Card = card;

            requestObj.PaymentInformation = paymentInformation;

            var consumerAuthenticationInformation = new Riskv1authenticationresultsConsumerAuthenticationInformation
            (
                AuthenticationTransactionId: "PYffv9G3sa1e0CQr5fV0",
                SignedPares: "eNqdmFmT4jgSgN+J4D90zD4yMz45PEFVhHzgA2zwjXnzhQ984Nvw61dAV1"
            );

            requestObj.ConsumerAuthenticationInformation = consumerAuthenticationInformation;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PayerAuthenticationApi(clientConfig);

                var result = apiInstance.ValidateAuthenticationResults(requestObj);
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
