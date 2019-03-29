using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Model;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class ProcessAuthorizationReversalWithServiceFee
    {
        public static PtsV2PaymentsReversalsPost201Response Run()
        {
            var processPaymentId = ProcessPaymentWithServiceFee.Run().Id;
            var requestBody = new AuthReversalRequest();
            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("TC50171_3");
            requestBody.ClientReferenceInformation = clientReferenceInformationObj;
            var v2paymentsidreversalsReversalInformationObj = new Ptsv2paymentsidreversalsReversalInformation
            {
                Reason = "34"
            };
            var v2paymentsidreversalsReversalInformationAmountDetailsobj = new Ptsv2paymentsidreversalsReversalInformationAmountDetails
            {
                TotalAmount = "2325.00"
            };
            v2paymentsidreversalsReversalInformationObj.AmountDetails = v2paymentsidreversalsReversalInformationAmountDetailsobj;
            requestBody.ReversalInformation = v2paymentsidreversalsReversalInformationObj;
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
