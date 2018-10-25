using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class UpdateInstrumentIdentifier
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreateInstrumentIdentifier.Run().Id;

            var requestObj = new Body1();

            var processingInformationObj = new InstrumentidentifiersProcessingInformation();

            var authorizationOptionsObj = new InstrumentidentifiersProcessingInformationAuthorizationOptions();

            var initiatorObj = new InstrumentidentifiersProcessingInformationAuthorizationOptionsInitiator();

            var merchantInitiatedTransactionObj = new InstrumentidentifiersProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction();

            merchantInitiatedTransactionObj.PreviousTransactionId = "123456789012345";
            initiatorObj.MerchantInitiatedTransaction = merchantInitiatedTransactionObj;

            authorizationOptionsObj.Initiator = initiatorObj;

            processingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = processingInformationObj;

            try
            {
                var apiInstance = new InstrumentIdentifierApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.InstrumentidentifiersTokenIdPatch(profileId, tokenId, requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
