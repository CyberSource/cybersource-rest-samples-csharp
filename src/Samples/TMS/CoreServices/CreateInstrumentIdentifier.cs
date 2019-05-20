using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreateInstrumentIdentifier
    {
        public static TmsV1InstrumentIdentifiersPost200Response Run()
        {
            var requestObj = new CreateInstrumentIdentifierRequest();

            var cardObj = new Tmsv1instrumentidentifiersCard
            {
                Number = "1234567123487456"
            };

            requestObj.Card = cardObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new InstrumentIdentifierApi(clientConfig);

                var result = apiInstance.CreateInstrumentIdentifier("93B32398-AD51-4CC2-A682-EA3E93614EB1", requestObj);
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
