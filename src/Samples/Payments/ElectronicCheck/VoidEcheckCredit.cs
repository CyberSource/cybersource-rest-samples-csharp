
using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ElectronicCheck
{
    public class VoidEcheckCredit
    {
    public static void Run()
        {
            var processCreditId = ProcessEcheckCredit.Run().Id;

            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_credit_void");
            var requestBody = new VoidCreditRequest(clientReferenceInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new VoidApi(clientConfig);

                var result = apiInstance.VoidCredit(requestBody, processCreditId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
