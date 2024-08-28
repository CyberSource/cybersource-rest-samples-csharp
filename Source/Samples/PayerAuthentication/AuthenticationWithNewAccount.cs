using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class AuthenticationWithNewAccount
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1AuthenticationsPost201Response Run()
        {
            string clientReferenceInformationCode = "New Account";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
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

            string paymentInformationCardType = "001";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            string paymentInformationCardNumber = "4000990000000004";
            Riskv1authenticationsetupsPaymentInformationCard paymentInformationCard = new Riskv1authenticationsetupsPaymentInformationCard(
                Type: paymentInformationCardType,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                Number: paymentInformationCardNumber
           );

            Riskv1authenticationsPaymentInformation paymentInformation = new Riskv1authenticationsPaymentInformation(
                Card: paymentInformationCard
           );

            string consumerAuthenticationInformationTransactionMode = "MOTO";
            Riskv1decisionsConsumerAuthenticationInformation consumerAuthenticationInformation = new Riskv1decisionsConsumerAuthenticationInformation(
                TransactionMode: consumerAuthenticationInformationTransactionMode
           );

            string riskInformationBuyerHistoryCustomerAccountCreationHistory = "NEW_ACCOUNT";
            Ptsv2paymentsRiskInformationBuyerHistoryCustomerAccount riskInformationBuyerHistoryCustomerAccount = new Ptsv2paymentsRiskInformationBuyerHistoryCustomerAccount(
                CreationHistory: riskInformationBuyerHistoryCustomerAccountCreationHistory
           );

            bool riskInformationBuyerHistoryAccountHistoryFirstUseOfShippingAddress = false;
            Ptsv2paymentsRiskInformationBuyerHistoryAccountHistory riskInformationBuyerHistoryAccountHistory = new Ptsv2paymentsRiskInformationBuyerHistoryAccountHistory(
                FirstUseOfShippingAddress: riskInformationBuyerHistoryAccountHistoryFirstUseOfShippingAddress
           );

            Ptsv2paymentsRiskInformationBuyerHistory riskInformationBuyerHistory = new Ptsv2paymentsRiskInformationBuyerHistory(
                CustomerAccount: riskInformationBuyerHistoryCustomerAccount,
                AccountHistory: riskInformationBuyerHistoryAccountHistory
           );

            Riskv1authenticationsRiskInformation riskInformation = new Riskv1authenticationsRiskInformation(
                BuyerHistory: riskInformationBuyerHistory
           );

            var requestObj = new CheckPayerAuthEnrollmentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                PaymentInformation: paymentInformation,
                ConsumerAuthenticationInformation: consumerAuthenticationInformation,
                RiskInformation: riskInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationsPost201Response result = apiInstance.CheckPayerAuthEnrollment(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
