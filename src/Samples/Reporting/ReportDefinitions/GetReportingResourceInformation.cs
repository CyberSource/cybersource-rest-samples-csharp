using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetReportingResourceInformation
    {
        public static ReportingV3ReportDefinitionsGet200Response Run()
        {
            string subscriptionType = null;
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportDefinitionsApi(clientConfig);
                ReportingV3ReportDefinitionsGet200Response result = apiInstance.GetResourceV2Info(subscriptionType, organizationId);
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
