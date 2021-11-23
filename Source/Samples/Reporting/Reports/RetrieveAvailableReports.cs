using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class RetrieveAvailableReports
    {
        public static ReportingV3ReportsGet200Response Run()
        {
            string organizationId = null;
            var startTime = DateTime.ParseExact("2021-04-01T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2021-04-03T23:59:59Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string timeQueryType = "executedTime";
            string reportMimeType = "application/xml";
            string reportFrequency = null;
            string reportName = null;
            int? reportDefinitionId = (int?)null;
            string reportStatus = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportsApi(clientConfig);
                ReportingV3ReportsGet200Response result = apiInstance.SearchReports(startTime, endTime, timeQueryType, organizationId, reportMimeType, reportFrequency, reportName, reportDefinitionId, reportStatus);
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
