using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class DownloadDTDForReport
    {
        public static void Run(string reportDefinitionNameVersion)
        {
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new DownloadDTDApi(clientConfig);
                apiInstance.GetDTDV2(reportDefinitionNameVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
            }
        }
    }
}
