using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RiskManagement
{
    public class RemoveFromHistory
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static RiskV1UpdatePost201Response Run()
        {
            string id = "5825489395116729903003";
            string riskInformationMarkingDetailsNotes = "Adding this transaction as suspect";
            string riskInformationMarkingDetailsReason = "suspected";
            string riskInformationMarkingDetailsAction = "hide";
            Riskv1decisionsidmarkingRiskInformationMarkingDetails riskInformationMarkingDetails = new Riskv1decisionsidmarkingRiskInformationMarkingDetails(
                Notes: riskInformationMarkingDetailsNotes,
                Reason: riskInformationMarkingDetailsReason,
                Action: riskInformationMarkingDetailsAction
           );

            Riskv1decisionsidmarkingRiskInformation riskInformation = new Riskv1decisionsidmarkingRiskInformation(
                MarkingDetails: riskInformationMarkingDetails
           );

            var requestObj = new FraudMarkingActionRequest(
                RiskInformation: riskInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DecisionManagerApi(clientConfig);
                RiskV1UpdatePost201Response result = apiInstance.FraudUpdate(id, requestObj);
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
