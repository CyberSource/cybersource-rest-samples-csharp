using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class UpdateInstrumentIdentifier
    {
        public static void Run()
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreateInstrumentIdentifier.Run().Id;

            var requestObj = new UpdateInstrumentIdentifierRequest();

            var processingInformationObj = new TmsV1InstrumentIdentifiersPost200ResponseProcessingInformation();

            var authorizationOptionsObj = new TmsV1InstrumentIdentifiersPost200ResponseProcessingInformationAuthorizationOptions();

            var initiatorObj = new TmsV1InstrumentIdentifiersPost200ResponseProcessingInformationAuthorizationOptionsInitiator();

            var merchantInitiatedTransactionObj =
                new TmsV1InstrumentIdentifiersPost200ResponseProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction
                {
                    PreviousTransactionId = "123456789012345"
                };

            initiatorObj.MerchantInitiatedTransaction = merchantInitiatedTransactionObj;

            authorizationOptionsObj.Initiator = initiatorObj;

            processingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = processingInformationObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new InstrumentIdentifierApi(clientConfig);

                var result = apiInstance.UpdateInstrumentIdentifier(profileId, tokenId, requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
