// Code Generated: getPaymentBatchSummary[Get payment batch summary data]

using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetPaymentBatchSummaryData
    {
        public static void Run()
        {
            var startTime = DateTime.ParseExact("2019-05-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2019-08-30T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string organizationId = "testrest";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentBatchSummariesApi(clientConfig);
                var result = apiInstance.GetPaymentBatchSummary(startTime, endTime, organizationId);
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}