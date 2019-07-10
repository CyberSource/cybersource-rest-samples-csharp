using CyberSource.Api;
using CyberSource.Model;
using System;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication.CoreServices
{
    public class AuthenticationWithNoRedirect
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
                Number: "4000990000000004"
            );

            paymentInformation.Card = card;

            requestObj.PaymentInformation = paymentInformation;

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
