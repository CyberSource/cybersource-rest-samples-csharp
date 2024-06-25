using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateInstrumentIdentifierBankAccount
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PostInstrumentIdentifierRequest Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            string bankAccountNumber = "4100";
            string bankAccountRoutingNumber = "071923284";
            TmsEmbeddedInstrumentIdentifierBankAccount bankAccount = new TmsEmbeddedInstrumentIdentifierBankAccount(
                Number: bankAccountNumber,
                RoutingNumber: bankAccountRoutingNumber
           );

            var requestObj = new PostInstrumentIdentifierRequest(
                BankAccount: bankAccount
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                PostInstrumentIdentifierRequest result = apiInstance.PostInstrumentIdentifier(requestObj, profileid);
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
