using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class RetrieveInstrumentIdentifier
    {
        public static Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifier Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = "7010000000016241111";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                Tmsv2customersEmbeddedDefaultPaymentInstrumentEmbeddedInstrumentIdentifier result = apiInstance.GetInstrumentIdentifier(tokenId, profileid);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
