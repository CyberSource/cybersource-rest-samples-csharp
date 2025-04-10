using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class UpdateInstrumentIdentifierPreviousTransactionId
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
            string processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransactionPreviousTransactionId = "123456789012345";
            TmsAuthorizationOptionsInitiatorMerchantInitiatedTransaction processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction = new TmsAuthorizationOptionsInitiatorMerchantInitiatedTransaction(
                PreviousTransactionId: processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransactionPreviousTransactionId
           );

            TmsAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new TmsAuthorizationOptionsInitiator(
                MerchantInitiatedTransaction: processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction
           );

            TmsAuthorizationOptions processingInformationAuthorizationOptions = new TmsAuthorizationOptions(
                Initiator: processingInformationAuthorizationOptionsInitiator
           );

            TmsEmbeddedInstrumentIdentifierProcessingInformation processingInformation = new TmsEmbeddedInstrumentIdentifierProcessingInformation(
                AuthorizationOptions: processingInformationAuthorizationOptions
           );

            var requestObj = new PatchInstrumentIdentifierRequest(
                ProcessingInformation: processingInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                apiInstance.PatchInstrumentIdentifier(instrumentIdentifierTokenId, requestObj);
                Console.WriteLine($"Instrument Identifier {instrumentIdentifierTokenId} has been updated with previous transaction ID.");
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
