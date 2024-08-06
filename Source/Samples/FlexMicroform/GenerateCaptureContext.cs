using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.FlexMicroform
{
    class GenerateCaptureContext
    {
        public static String Run()
        {
            List<String> targetOrigins = new List<String>()
            {
                "https://www.test.com"
            };

            List<String> allowedCardNetworks = new List<String>()
            {
                "VISA",
                "MAESTRO",
                "MASTERCARD",
                "AMEX",
                "DISCOVER",
                "DINERSCLUB",
                "JCB",
                "CUP",
                "CARTESBANCAIRES"
            };

            string clientVerison = "v2.0";

            var requestObj = new GenerateCaptureContextRequest(
                TargetOrigins: targetOrigins,
                AllowedCardNetworks: allowedCardNetworks,
                ClientVersion: clientVerison
            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MicroformIntegrationApi(clientConfig);
                String result = apiInstance.GenerateCaptureContext(requestObj);
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
