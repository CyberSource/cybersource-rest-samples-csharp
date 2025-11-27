using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CyberSource.Api;
using CyberSource.Model;
using CyberSource.Utilities.CaptureContext;

namespace Cybersource_rest_samples_dotnet.Samples.FlexMicroform
{
    class GenerateCaptureContextAcceptCard
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static String Run()
        {
            string clientVersion = "v2";

            List<string> targetOrigins = new List<string>();
            targetOrigins.Add("https://www.test.com");

            List<string> allowedCardNetworks = new List<string>();
            allowedCardNetworks.Add("VISA");
            allowedCardNetworks.Add("MASTERCARD");
            allowedCardNetworks.Add("AMEX");
            allowedCardNetworks.Add("CARNET");
            allowedCardNetworks.Add("CARTESBANCAIRES");
            allowedCardNetworks.Add("CUP");
            allowedCardNetworks.Add("DINERSCLUB");
            allowedCardNetworks.Add("DISCOVER");
            allowedCardNetworks.Add("EFTPOS");
            allowedCardNetworks.Add("ELO");
            allowedCardNetworks.Add("JCB");
            allowedCardNetworks.Add("JCREW");
            allowedCardNetworks.Add("MADA");
            allowedCardNetworks.Add("MAESTRO");
            allowedCardNetworks.Add("MEEZA");
            List<string> allowedPaymentTypes = new List<string>();
            allowedPaymentTypes.Add("CARD");
            var requestObj = new GenerateCaptureContextRequest(
                ClientVersion: clientVersion,
                TargetOrigins: targetOrigins,
                AllowedCardNetworks: allowedCardNetworks,
                AllowedPaymentTypes: allowedPaymentTypes

            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MicroformIntegrationApi(clientConfig);
                String result = apiInstance.GenerateCaptureContext(requestObj);
                Console.WriteLine(CaptureContextParsingUtility.parseCaptureContextResponse(result, clientConfig));
                WriteLogAudit(apiInstance.GetStatusCode());
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
