using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class CreateReportSubscriptionForReportNameByOrganization
    {
        public static void Run()
        {
            const string reportName = "testrest_subcription_v1";

            var request = new RequestBody1(
                ReportDefinitionName: "TransactionRequestClass",
                ReportMimeType: RequestBody1.ReportMimeTypeEnum.ApplicationXml,
                ReportFields: new List<string>() {"Request.RequestID", "Request.TransactionDate", "Request.MerchantID"},
                ReportName: reportName,
                ReportFrequency: RequestBody1.ReportFrequencyEnum.WEEKLY,
                Timezone: "GMT",
                StartTime: "0115",
                StartDay: 1);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportSubscriptionsApi(clientConfig);

                apiInstance.CreateSubscription(request);

                DeleteSubscriptionOfReportNameByOrganization.ReportNameToDelete = reportName;
                DeleteSubscriptionOfReportNameByOrganization.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
