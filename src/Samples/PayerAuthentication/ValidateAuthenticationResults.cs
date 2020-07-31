using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class ValidateAuthenticationResults
    {
        public static RiskV1AuthenticationResultsPost201Response Run()
        {
            string clientReferenceInformationCode = "pavalidatecheck";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsTotalAmount = "200.00";
            Riskv1authenticationsOrderInformationAmountDetails orderInformationAmountDetails = new Riskv1authenticationsOrderInformationAmountDetails(
                Currency: orderInformationAmountDetailsCurrency,
                TotalAmount: orderInformationAmountDetailsTotalAmount
           );


            List<Riskv1authenticationresultsOrderInformationLineItems> orderInformationLineItems = new List<Riskv1authenticationresultsOrderInformationLineItems>();
            string orderInformationLineItemsUnitPrice1 = "10";
            int orderInformationLineItemsQuantity1 = 2;
            string orderInformationLineItemsTaxAmount1 = "32.40";
            orderInformationLineItems.Add(new Riskv1authenticationresultsOrderInformationLineItems(
                UnitPrice: orderInformationLineItemsUnitPrice1,
                Quantity: orderInformationLineItemsQuantity1,
                TaxAmount: orderInformationLineItemsTaxAmount1
           ));

            Riskv1authenticationresultsOrderInformation orderInformation = new Riskv1authenticationresultsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                LineItems: orderInformationLineItems
           );

            string paymentInformationCardType = "002";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            string paymentInformationCardNumber = "5200000000000007";
            Riskv1authenticationresultsPaymentInformationCard paymentInformationCard = new Riskv1authenticationresultsPaymentInformationCard(
                Type: paymentInformationCardType,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Number: paymentInformationCardNumber
           );

            Riskv1authenticationresultsPaymentInformation paymentInformation = new Riskv1authenticationresultsPaymentInformation(
                Card: paymentInformationCard
           );

            string consumerAuthenticationInformationAuthenticationTransactionId = "PYffv9G3sa1e0CQr5fV0";
            string consumerAuthenticationInformationResponseAccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI5YTAwYTYzMC0zNzFhLTExZTYtYTU5Ni1kZjQwZjUwMjAwNmMiLCJpYXQiOjE0NjY0NDk4MDcsImlzcyI6Ik1pZGFzLU5vRFYtS2V5IiwiUGF5bG9hZCI6eyJPcmRlckRldGFpbHMiOnsiT3JkZXJOdW1iZXIiOjE1NTc4MjAyMzY3LCJBbW91bnQiOiIxNTAwIiwiQ3VycmVudENvZGUiOiI4NDAiLCJUcmFuc2FjdGlvbklkIjoiOVVzaGVoRFFUcWh1SFk5SElqZTAifX0sIk9yZ1VuaXRJZCI6IjU2NGNkY2JjYjlmNjNmMGM0OGQ2Mzg3ZiIsIk9iamVjdGlmeVBheWxvYWQiOnRydWV9.eaU8LZJnMtY3mPl4vBXVCVUuyeSeAp8zoNaEOmKS4XY";
            string consumerAuthenticationInformationSignedPares = "eNqdmFmT4jgSgN+J4D90zD4yMz45PEFVhHzgA2zwjXnzhQ984Nvw61dAV1";
            Riskv1authenticationresultsConsumerAuthenticationInformation consumerAuthenticationInformation = new Riskv1authenticationresultsConsumerAuthenticationInformation(
                AuthenticationTransactionId: consumerAuthenticationInformationAuthenticationTransactionId,
                ResponseAccessToken: consumerAuthenticationInformationResponseAccessToken,
                SignedPares: consumerAuthenticationInformationSignedPares
           );

            var requestObj = new ValidateRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                PaymentInformation: paymentInformation,
                ConsumerAuthenticationInformation: consumerAuthenticationInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationResultsPost201Response result = apiInstance.ValidateAuthenticationResults(requestObj);
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
