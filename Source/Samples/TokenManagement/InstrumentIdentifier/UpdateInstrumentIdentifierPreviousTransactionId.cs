using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class UpdateInstrumentIdentifierPreviousTransactionId
    {
        public static void Run()
        {
            string instrumentIdentifierTokenId = "7010000000016241111";
            string processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransactionPreviousTransactionId = "123456789012345";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction(
                PreviousTransactionId: processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransactionPreviousTransactionId
           );

            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptionsInitiator(
                MerchantInitiatedTransaction: processingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction
           );

            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformationAuthorizationOptions(
                Initiator: processingInformationAuthorizationOptionsInitiator
           );

            Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformation processingInformation = new Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifierProcessingInformation(
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
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
