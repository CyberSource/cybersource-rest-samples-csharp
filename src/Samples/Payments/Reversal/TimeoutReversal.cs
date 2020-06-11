using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class TimeoutReversal
    {
        public static PtsV2PaymentsReversalsPost201Response Run()
        {
            AuthorizationForTimeoutReversalFlow.Run();
            var clientReferenceInformationTransactionId = "231465978312";
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode,
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
                PtsV2PaymentsReversalsPost201Response result = apiInstance.MitReversal(requestObj);
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
