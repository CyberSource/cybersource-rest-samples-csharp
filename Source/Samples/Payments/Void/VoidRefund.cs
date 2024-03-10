using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class VoidRefund
    {
        public static PtsV2PaymentsVoidsPost201Response Run()
        {
            var id = RefundPayment.Run().Id;

            string clientReferenceInformationCode = "test_void";
            Ptsv2paymentsidreversalsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidreversalsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            var requestObj = new VoidRefundRequest(
                ClientReferenceInformation: clientReferenceInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new VoidApi(clientConfig);
                PtsV2PaymentsVoidsPost201Response result = apiInstance.VoidRefund(requestObj, id);
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
