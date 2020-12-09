using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class SetupCompletionWithCardNumber
    {
        public static RiskV1AuthenticationSetupsPost201Response Run()
        {
            string clientReferenceInformationCode = "cybs_test";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCardType = "001";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            string paymentInformationCardNumber = "4000000000000101";
            Riskv1authenticationsetupsPaymentInformationCard paymentInformationCard = new Riskv1authenticationsetupsPaymentInformationCard(
                Type: paymentInformationCardType,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Number: paymentInformationCardNumber
           );

            Riskv1authenticationsetupsPaymentInformation paymentInformation = new Riskv1authenticationsetupsPaymentInformation(
                Card: paymentInformationCard
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
