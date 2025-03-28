using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetPurchaseAndRefundDetails
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static ReportingV3PurchaseRefundDetailsGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2025-01-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2025-01-30T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string organizationId = "testrest";
            string paymentSubtype = "VI";
            string viewBy = "requestDate";
            string groupName = "groupName";
            int? offset = 20;
            int? limit = 2000;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PurchaseAndRefundDetailsApi(clientConfig);
                ReportingV3PurchaseRefundDetailsGet200Response result = apiInstance.GetPurchaseAndRefundDetails(startTime, endTime, organizationId, paymentSubtype, viewBy, groupName, offset, limit);
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
