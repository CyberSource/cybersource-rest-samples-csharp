using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class TimeoutReversal
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static async System.Threading.Tasks.Task<PtsV2PaymentsReversalsPost201Response> RunAsync()
        {
            await AuthorizationForTimeoutReversalFlow.RunAsync();
            var clientReferenceInformationTransactionId = SampleCode.TimeoutReversalTransactionId;
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                TransactionId: clientReferenceInformationTransactionId
           );

            string reversalInformationAmountDetailsTotalAmount = "102.21";

            Ptsv2paymentsidreversalsReversalInformationAmountDetails reversalInformationAmountDetails = new Ptsv2paymentsidreversalsReversalInformationAmountDetails(
                TotalAmount: reversalInformationAmountDetailsTotalAmount
           );

            string reversalInformationReason = "Testing";

            Ptsv2paymentsidreversalsReversalInformation reversalInformation = new Ptsv2paymentsidreversalsReversalInformation(
                AmountDetails: reversalInformationAmountDetails,
                Reason: reversalInformationReason
           );

            var requestObj = new MitReversalRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ReversalInformation: reversalInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReversalApi(clientConfig);
                PtsV2PaymentsReversalsPost201Response result = await apiInstance.MitReversalAsync(requestObj);
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
