using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetPaymentBatchSummaryData
    {
        public static ReportingV3PaymentBatchSummariesGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2019-05-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2019-08-30T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
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
