using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;

namespace CybsPayments.TMS
{
    public class RetrievePaymentIdentifiers
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = "";

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "GET",
                RequestTarget = "/tms/v1/paymentinstruments/" + tokenId
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new PaymentInstrumentApi(configurationSwagger);
                var result = apiInstance.PaymentinstrumentsTokenIdGet(profileId, tokenId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
