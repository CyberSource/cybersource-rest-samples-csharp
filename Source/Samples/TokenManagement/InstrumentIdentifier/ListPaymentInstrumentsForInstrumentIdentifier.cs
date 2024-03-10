using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class ListPaymentInstrumentsForInstrumentIdentifier
    {
        public static PaymentInstrumentList Run()
        {
            string instrumentIdentifierTokenId = "7010000000016241111";
            string profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            long? offset = (long?)null;
            long? limit = (long?)null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                PaymentInstrumentList result = apiInstance.GetInstrumentIdentifierPaymentInstrumentsList(instrumentIdentifierTokenId, profileid, offset, limit);
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
