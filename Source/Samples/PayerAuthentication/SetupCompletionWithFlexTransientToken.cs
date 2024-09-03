using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.PayerAuthentication
{
    public class SetupCompletionWithFlexTransientToken
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1AuthenticationSetupsPost201Response Run()
        {
            string clientReferenceInformationCode = "cybs_test";
            Riskv1authenticationsetupsClientReferenceInformation clientReferenceInformation = new Riskv1authenticationsetupsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string tokenInformationTransientToken = "1D5ZX4HMOV20FKEBE3IO240JWYJ0NJ90B4V9XQ6SCK4BDN0W96E65E2A39052056";
            Riskv1authenticationsetupsTokenInformation tokenInformation = new Riskv1authenticationsetupsTokenInformation(
                TransientToken: tokenInformationTransientToken
           );

            var requestObj = new PayerAuthSetupRequest(
                ClientReferenceInformation: clientReferenceInformation,
                TokenInformation: tokenInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayerAuthenticationApi(clientConfig);
                RiskV1AuthenticationSetupsPost201Response result = apiInstance.PayerAuthSetup(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
