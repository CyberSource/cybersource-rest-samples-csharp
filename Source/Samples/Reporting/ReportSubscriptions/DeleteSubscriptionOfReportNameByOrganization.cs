using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DeleteSubscriptionOfReportNameByOrganization
    {
        public static string ReportNameToDelete { get; set; }

        public static void Run()
        {
            if (string.IsNullOrEmpty(ReportNameToDelete))
            {
                ReportNameToDelete = "testrest_subcription_v1";
            }

            string reportName = ReportNameToDelete;
            string organizationId = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportSubscriptionsApi(clientConfig);
                apiInstance.DeleteSubscription(reportName, organizationId);
                ReportNameToDelete = null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
