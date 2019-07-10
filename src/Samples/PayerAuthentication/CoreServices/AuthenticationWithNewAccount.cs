using CyberSource.Api;
using CyberSource.Model;
using System;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication.CoreServices
{
    public class AuthenticationWithNewAccount
    {
        public static RiskV1AuthenticationsPost201Response Run()
        {
            var requestObj = new CheckPayerAuthEnrollmentRequest();

            var clientReferenceInformation = new Riskv1authenticationsClientReferenceInformation(Code: "New Account");

            // clientReferenceInformation.Code = "New Account";
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
                Number: "4000000000000101"
            );

            paymentInformation.Card = card;

            requestObj.PaymentInformation = paymentInformation;

            var consumerAuthenticationInformation = new Riskv1authenticationsConsumerAuthenticationInformation(TransactionMode: "MOTO", Mcc: string.Empty, ReferenceId: string.Empty);

            requestObj.ConsumerAuthenticationInformation = consumerAuthenticationInformation;

            var riskInformation = new Riskv1authenticationsRiskInformation();

            var buyerHistory = new Riskv1authenticationsRiskInformationBuyerHistory();

            var customerAccount = new Riskv1authenticationsRiskInformationBuyerHistoryCustomerAccount(CreationHistory: "NEW_ACCOUNT");

            buyerHistory.CustomerAccount = customerAccount;

            var accountHistory = new Riskv1authenticationsRiskInformationBuyerHistoryAccountHistory(FirstUseOfShippingAddress: false);

            buyerHistory.AccountHistory = accountHistory;

            riskInformation.BuyerHistory = buyerHistory;

            requestObj.RiskInformation = riskInformation;

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
