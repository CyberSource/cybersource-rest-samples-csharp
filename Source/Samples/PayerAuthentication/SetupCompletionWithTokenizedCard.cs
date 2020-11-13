using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class SetupCompletionWithTokenizedCard
    {
        public static RiskV1AuthenticationSetupsPost201Response Run()
        {
            string clientReferenceInformationCode = "cybs_test";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationTokenizedCardTransactionType = "1";
            string paymentInformationTokenizedCardType = "001";
            string paymentInformationTokenizedCardExpirationMonth = "11";
            string paymentInformationTokenizedCardExpirationYear = "2025";
            string paymentInformationTokenizedCardNumber = "4111111111111111";
            Riskv1authenticationsetupsPaymentInformationTokenizedCard paymentInformationTokenizedCard = new Riskv1authenticationsetupsPaymentInformationTokenizedCard(
                TransactionType: paymentInformationTokenizedCardTransactionType,
                Type: paymentInformationTokenizedCardType,
                ExpirationMonth: paymentInformationTokenizedCardExpirationMonth,
                ExpirationYear: paymentInformationTokenizedCardExpirationYear,
                Number: paymentInformationTokenizedCardNumber
           );

            Riskv1authenticationsetupsPaymentInformation paymentInformation = new Riskv1authenticationsetupsPaymentInformation(
                TokenizedCard: paymentInformationTokenizedCard
           );

            var requestObj = new PayerAuthSetupRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationSetupsPost201Response result = apiInstance.PayerAuthSetup(requestObj);
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
