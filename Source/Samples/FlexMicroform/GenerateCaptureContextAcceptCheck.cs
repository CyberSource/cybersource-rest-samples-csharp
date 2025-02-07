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
    class GenerateCaptureContextAcceptCheck
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
            List<string> allowedPaymentTypes = new List<string>();
            allowedPaymentTypes.Add("CHECK");
            var requestObj = new GenerateCaptureContextRequest(
                ClientVersion: clientVersion,
                TargetOrigins: targetOrigins,
                AllowedPaymentTypes: allowedPaymentTypes);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MicroformIntegrationApi(clientConfig);
                String result = apiInstance.GenerateCaptureContext(requestObj);
                Console.WriteLine(result);
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
