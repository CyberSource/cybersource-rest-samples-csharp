using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DownloadReport
    {
        public static void Run()
        {
            string organizationId = "testrest";
            var reportDate = DateTime.ParseExact("2018-09-30", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string reportName = "Demo_Report";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportDownloadsApi(clientConfig);
                apiInstance.DownloadReport(reportDate, reportName, organizationId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
