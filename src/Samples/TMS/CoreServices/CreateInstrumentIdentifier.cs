using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreateInstrumentIdentifier
    {
        public static InlineResponse20010 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var requestObj = new Body();

            var cardObj = new Tmsv1instrumentidentifiersCard
            {
                Number = "1234567890987456"
            };

            requestObj.Card = cardObj;

            var processingInformationObj = new Tmsv1instrumentidentifiersProcessingInformation();

            var authorizationOptionsObj = new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptions();

            var initiatorObj = new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptionsInitiator();

            var merchantInitiatedTransactionObj =
                new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction
                {
                    PreviousTransactionId = "123456789012345"
                };

            initiatorObj.MerchantInitiatedTransaction = merchantInitiatedTransactionObj;

            authorizationOptionsObj.Initiator = initiatorObj;

            processingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = processingInformationObj;

            try
            {
                var apiInstance = new InstrumentIdentifiersApi();
                var result = apiInstance.TmsV1InstrumentidentifiersPost("93B32398-AD51-4CC2-A682-EA3E93614EB1", requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
