using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.TMS
{
    public class RemoveInstrumentIdentifier
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = "7020000000000137654";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "DELETE",
                RequestTarget = "/tms/v1/instrumentidentifiers/" + tokenId
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new InstrumentIdentifierApi(configurationSwagger);
                var result = apiInstance.InstrumentidentifiersTokenIdDeleteWithHttpInfo(profileId, tokenId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
