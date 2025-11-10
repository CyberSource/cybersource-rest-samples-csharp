using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class EnrollInstrumentIdentifierForNetworkTokenization
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static void Run()
        {
            string instrumentIdentifierTokenId = "7010000000016241111";
            string profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string type = "enrollable card";
            string cardExpirationMonth = "12";
            string cardExpirationYear = "2031";
            string cardSecurityCode = "123";
            TmsEmbeddedInstrumentIdentifierCard card = new TmsEmbeddedInstrumentIdentifierCard(
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                SecurityCode: cardSecurityCode
           );

            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            TmsEmbeddedInstrumentIdentifierBillTo billTo = new TmsEmbeddedInstrumentIdentifierBillTo(
                Address1: billToAddress1,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry
           );

            var requestObj = new PostInstrumentIdentifierEnrollmentRequest(
                Type: type,
                Card: card,
                BillTo: billTo
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                apiInstance.PostInstrumentIdentifierEnrollment(instrumentIdentifierTokenId, requestObj, profileid);
                Console.WriteLine($"Instrument Identifier for Network Tokenized Card {instrumentIdentifierTokenId} has been enrolled.");
                WriteLogAudit(apiInstance.GetStatusCode());
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
            }
        }
    }
}
