using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ProcessAuthorizationReversal
    {
        public static PtsV2PaymentsReversalsPost201Response Run()
        {
            SimpleAuthorizationInternet.CaptureTrueForProcessPayment = false;
            var id = SimpleAuthorizationInternet.Run().Id;

            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsidreversalsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidreversalsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string reversalInformationAmountDetailsTotalAmount = "102.21";
            Ptsv2paymentsidreversalsReversalInformationAmountDetails reversalInformationAmountDetails = new Ptsv2paymentsidreversalsReversalInformationAmountDetails(
                TotalAmount: reversalInformationAmountDetailsTotalAmount
           );

            string reversalInformationReason = "testing";
            Ptsv2paymentsidreversalsReversalInformation reversalInformation = new Ptsv2paymentsidreversalsReversalInformation(
                AmountDetails: reversalInformationAmountDetails,
                Reason: reversalInformationReason
           );

            var requestObj = new AuthReversalRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ReversalInformation: reversalInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReversalApi(clientConfig);
                PtsV2PaymentsReversalsPost201Response result = apiInstance.AuthReversal(id, requestObj);
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
