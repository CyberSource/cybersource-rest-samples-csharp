using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.ValueAddedService
{
    public class VoidCommittedTaxCall
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static VasV2TaxVoid200Response Run()
        {
            string id = CommittedTaxCallRequest.Run().Id;
            string clientReferenceInformationCode = "TAX_TC001";
            Vasv2taxidClientReferenceInformation clientReferenceInformation = new Vasv2taxidClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            var requestObj = new VoidTaxRequest(
                ClientReferenceInformation: clientReferenceInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new TaxesApi(clientConfig);
                VasV2TaxVoid200Response result = apiInstance.VoidTax(requestObj, id);
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
