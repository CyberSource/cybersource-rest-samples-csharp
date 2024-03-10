using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateInstrumentIdentifierCard
    {
        public static TmsEmbeddedInstrumentIdentifier Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            string cardNumber = "411111111111111";
            TmsEmbeddedInstrumentIdentifierCard card = new TmsEmbeddedInstrumentIdentifierCard(
                Number: cardNumber
           );

            var requestObj = new PostInstrumentIdentifierRequest(
                Card: card
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new InstrumentIdentifierApi(clientConfig);
                TmsEmbeddedInstrumentIdentifier result = apiInstance.PostInstrumentIdentifier(requestObj, profileid);
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
