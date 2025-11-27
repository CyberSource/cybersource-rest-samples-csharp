using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateCustomerPaymentInstrumentPinlessDebit
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PostCustomerPaymentInstrumentRequest Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardType = "001";
            string cardIssueNumber = "01";
            string cardStartMonth = "01";
            string cardStartYear = "2020";
            string cardUseAs = "pinless debit";
            Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentCard card = new Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentCard(
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                Type: cardType,
                IssueNumber: cardIssueNumber,
                StartMonth: cardStartMonth,
                StartYear: cardStartYear,
                UseAs: cardUseAs
           );

            string billToFirstName = "John";
            string billToLastName = "Doe";
            string billToCompany = "CyberSource";
            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            string billToEmail = "test@cybs.com";
            string billToPhoneNumber = "4158880000";
            Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentBillTo billTo = new Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentBillTo(
                FirstName: billToFirstName,
                LastName: billToLastName,
                Company: billToCompany,
                Address1: billToAddress1,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry,
                Email: billToEmail,
                PhoneNumber: billToPhoneNumber
           );

            string instrumentIdentifierId = "7010000000016241111";
            Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentInstrumentIdentifier instrumentIdentifier = new Tmsv2tokenizeTokenInformationCustomerEmbeddedDefaultPaymentInstrumentInstrumentIdentifier(
                Id: instrumentIdentifierId
           );

            var requestObj = new PostCustomerPaymentInstrumentRequest(
                Card: card,
                BillTo: billTo,
                InstrumentIdentifier: instrumentIdentifier
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerPaymentInstrumentApi(clientConfig);
                PostCustomerPaymentInstrumentRequest result = apiInstance.PostCustomerPaymentInstrument(customerTokenId, requestObj);
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
