using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Token_Management
{
    public class RetrieveAllPaymentInstruments
    {
        public static TmsV1InstrumentIdentifiersPaymentInstrumentsGet200Response Run(string profileid, string tokenId)
        {
            long? offset = (long?)null;
            long? limit = (long?)null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                TmsV1InstrumentIdentifiersPaymentInstrumentsGet200Response result = apiInstance.GetAllPaymentInstruments(profileid, tokenId, offset, limit);
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
