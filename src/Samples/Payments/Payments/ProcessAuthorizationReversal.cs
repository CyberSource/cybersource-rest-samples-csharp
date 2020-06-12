using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ProcessAuthorizationReversal
    {
        public static PtsV2PaymentsReversalsPost201Response Run()
        {
            var processPaymentId = ProcessPayment.Run().Id;

            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_reversal");
            var amount = new Ptsv2paymentsidreversalsOrderInformationLineItems(null, "102.21");
            var amountDetailsObj = new List<Ptsv2paymentsidreversalsOrderInformationLineItems> { amount };
            var orderInformationObj = new Ptsv2paymentsidreversalsOrderInformation(null, amountDetailsObj);
            var requestBody = new AuthReversalRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReversalApi(clientConfig);

                var result = apiInstance.AuthReversal(processPaymentId, requestBody);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
