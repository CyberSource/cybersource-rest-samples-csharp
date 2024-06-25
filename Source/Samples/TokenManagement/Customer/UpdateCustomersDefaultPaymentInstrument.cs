using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class UpdateCustomersDefaultPaymentInstrument
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PatchCustomerRequest Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
            string defaultPaymentInstrumentId = "AB6A54B982A6FCB6E05341588E0A3935";
            Tmsv2customersDefaultPaymentInstrument defaultPaymentInstrument = new Tmsv2customersDefaultPaymentInstrument(
                Id: defaultPaymentInstrumentId
           );

            var requestObj = new PatchCustomerRequest(
                DefaultPaymentInstrument: defaultPaymentInstrument
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CustomerApi(clientConfig);
                PatchCustomerRequest result = apiInstance.PatchCustomer(customerTokenId, requestObj);
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
