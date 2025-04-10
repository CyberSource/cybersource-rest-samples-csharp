using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetPaymentBatchSummaryData
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static ReportingV3PaymentBatchSummariesGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2025-01-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2025-01-30T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string organizationId = "testrest";
            string rollUp = null;
            string breakdown = null;
            int? startDayOfWeek = (int?)null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentBatchSummariesApi(clientConfig);
                ReportingV3PaymentBatchSummariesGet200Response result = apiInstance.GetPaymentBatchSummary(startTime, endTime, organizationId, rollUp, breakdown, startDayOfWeek);
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
