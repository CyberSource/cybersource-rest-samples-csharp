using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetReportBasedOnReportId
    {
        public static ReportingV3ReportsIdGet200Response Run()
        {
            string reportId = "79642c43-2368-0cd5-e053-a2588e0a7b3c";
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportsApi(clientConfig);
                ReportingV3ReportsIdGet200Response result = apiInstance.GetReportByReportId(reportId, organizationId);
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
