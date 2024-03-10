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
            string clientReferenceInformationPartnerDeveloperId = "7891234";
            string clientReferenceInformationPartnerSolutionId = "89012345";
            Riskv1decisionsClientReferenceInformationPartner clientReferenceInformationPartner = new Riskv1decisionsClientReferenceInformationPartner(
                DeveloperId: clientReferenceInformationPartnerDeveloperId,
                SolutionId: clientReferenceInformationPartnerSolutionId
            );

            Riskv1decisionsClientReferenceInformation clientReferenceInformation = new Riskv1decisionsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Partner: clientReferenceInformationPartner
            );

            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsTotalAmount = "200.00";
            Riskv1authenticationresultsOrderInformationAmountDetails orderInformationAmountDetails = new Riskv1authenticationresultsOrderInformationAmountDetails(
                Currency: orderInformationAmountDetailsCurrency,
                TotalAmount: orderInformationAmountDetailsTotalAmount
            );

            Riskv1authenticationresultsOrderInformation orderInformation = new Riskv1authenticationresultsOrderInformation(
                AmountDetails: orderInformationAmountDetails
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
            string consumerAuthenticationInformationSignedPares = "eNqdmFmT4jgSgN+J4D90zD4yMz45PEFVhHzgA2zwjXnzhQ984Nvw61dAV1";
            Riskv1authenticationresultsConsumerAuthenticationInformation consumerAuthenticationInformation = new Riskv1authenticationresultsConsumerAuthenticationInformation(
                AuthenticationTransactionId: consumerAuthenticationInformationAuthenticationTransactionId,
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
