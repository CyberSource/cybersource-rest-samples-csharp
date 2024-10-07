using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class EnrollWithTransientToken
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1AuthenticationsPost201Response Run()
        {
            string clientReferenceInformationCode = "UNKNOWN";
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

            string tokenInformationTransientToken = "1D5ZX4HMOV20FKEBE3IO240JWYJ0NJ90B4V9XQ6SCK4BDN0W96E65E2A39052056";
            Riskv1authenticationsetupsTokenInformation tokenInformation = new Riskv1authenticationsetupsTokenInformation(
                TransientToken: tokenInformationTransientToken
           );

            var requestObj = new CheckPayerAuthEnrollmentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                TokenInformation: tokenInformation
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
