using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreatePaymentInstrumentPinlessDebit
    {
        public static Tmsv2customersEmbeddedDefaultPaymentInstrument Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardType = "visa";
            string cardIssueNumber = "01";
            string cardStartMonth = "01";
            string cardStartYear = "2020";
            string cardUseAs = "pinless debit";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentCard card = new Tmsv2customersEmbeddedDefaultPaymentInstrumentCard(
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
            Tmsv2customersEmbeddedDefaultPaymentInstrumentBillTo billTo = new Tmsv2customersEmbeddedDefaultPaymentInstrumentBillTo(
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

            Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier instrumentIdentifier = new Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier(
                Id: instrumentIdentifierId
           );

            var requestObj = new PostPaymentInstrumentRequest(
                Card: card,
                BillTo: billTo,
                InstrumentIdentifier: instrumentIdentifier
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentInstrumentApi(clientConfig);
                Tmsv2customersEmbeddedDefaultPaymentInstrument result = apiInstance.PostPaymentInstrument(requestObj, profileid);
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
