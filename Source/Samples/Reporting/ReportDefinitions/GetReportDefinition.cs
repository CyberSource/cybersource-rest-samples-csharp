using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetReportDefinition
    {
        public static ReportingV3ReportDefinitionsNameGet200Response Run()
        {
            string reportDefinitionName = "SubscriptionDetailClass";
            string subscriptionType = null;
            string reportMimeType = null;
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ReportDefinitionsApi(clientConfig);
                ReportingV3ReportDefinitionsNameGet200Response result = apiInstance.GetResourceInfoByReportDefinition(reportDefinitionName, subscriptionType, reportMimeType, organizationId);
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
