using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class UpdatePaymentInstrument
    {
        public static Tmsv2customersEmbeddedDefaultPaymentInstrument Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var paymentInstrumentTokenId = "888454C31FB6150CE05340588D0AA9BE";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardType = "visa";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentCard card = new Tmsv2customersEmbeddedDefaultPaymentInstrumentCard(
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                Type: cardType
           );

            string billToFirstName = "Jack";
            string billToLastName = "Smith";
            string billToCompany = "CyberSource";
            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            string billToEmail = "updatedemail@cybs.com";
            string billToPhoneNumber = "4158888674";
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

            var requestObj = new PatchPaymentInstrumentRequest(
                Card: card,
                BillTo: billTo,
                InstrumentIdentifier: instrumentIdentifier
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentInstrumentApi(clientConfig);
                Tmsv2customersEmbeddedDefaultPaymentInstrument result = apiInstance.PatchPaymentInstrument(paymentInstrumentTokenId, requestObj, profileid);
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
