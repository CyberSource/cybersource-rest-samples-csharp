using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class CreateReportSubscription
    {
        public static void Run()
        {
            string reportDefinitionName = "TransactionRequestClass";

            List <string> reportFields = new List <string>();
            reportFields.Add("Request.RequestID");
            reportFields.Add("Request.TransactionDate");
            reportFields.Add("Request.MerchantID");
            string reportMimeType = "application/xml";
            string reportFrequency = "WEEKLY";
            string reportName = "testrest_subcription_v1";
            string timezone = "GMT";
            string startTime = "0900";
            int startDay = 1;
            var requestObj = new CreateReportSubscriptionRequest(
                ReportDefinitionName: reportDefinitionName,
                ReportFields: reportFields,
                ReportMimeType: reportMimeType,
                ReportFrequency: reportFrequency,
                ReportName: reportName,
                Timezone: timezone,
                StartTime: startTime,
                StartDay: startDay
           );

            string organizationId = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportSubscriptionsApi(clientConfig);
                apiInstance.CreateSubscription(requestObj, organizationId);

                DeleteSubscriptionOfReportNameByOrganization.ReportNameToDelete = reportName;
                DeleteSubscriptionOfReportNameByOrganization.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
