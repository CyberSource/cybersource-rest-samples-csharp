using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class TimeoutVoid
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static async System.Threading.Tasks.Task<PtsV2PaymentsVoidsPost201Response> RunAsync()
        {
            await AuthorizationCaptureForTimeoutVoidFlow.RunAsync();
            string clientReferenceInformationTransactionId = SampleCode.TimeoutVoidTransactionId;
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                TransactionId: clientReferenceInformationTransactionId
           );

            var requestObj = new MitVoidRequest(
                ClientReferenceInformation: clientReferenceInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new VoidApi(clientConfig);
                PtsV2PaymentsVoidsPost201Response result = await apiInstance.MitVoidAsync(requestObj);
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
