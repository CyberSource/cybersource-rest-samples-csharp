using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreateInstrumentIdentifier
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new Body();

            var cardObj = new InstrumentidentifiersCard();

            cardObj.Number = "1234567890987654";
            requestObj.Card = cardObj;

            var processingInformationObj = new InstrumentidentifiersProcessingInformation();

            var authorizationOptionsObj = new InstrumentidentifiersProcessingInformationAuthorizationOptions();

            var initiatorObj = new InstrumentidentifiersProcessingInformationAuthorizationOptionsInitiator();

            var merchantInitiatedTransactionObj = new InstrumentidentifiersProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction();

            merchantInitiatedTransactionObj.PreviousTransactionId = "123456789012345";
            initiatorObj.MerchantInitiatedTransaction = merchantInitiatedTransactionObj;

            authorizationOptionsObj.Initiator = initiatorObj;

            processingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = processingInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/tms/v1/instrumentidentifiers",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new InstrumentIdentifierApi(configurationSwagger);
                var result = apiInstance.InstrumentidentifiersPost("93B32398-AD51-4CC2-A682-EA3E93614EB1", requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
