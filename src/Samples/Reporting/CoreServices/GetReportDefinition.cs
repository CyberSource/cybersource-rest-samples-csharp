using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetReportDefinition
    {
        public static void Run()
        {
            const string reportDefinitionName = "SubscriptionDetailClass";

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportDefinitionsApi(clientConfig);

                var result = apiInstance.GetResourceInfoByReportDefinition(reportDefinitionName);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
