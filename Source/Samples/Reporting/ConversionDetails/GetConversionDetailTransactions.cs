using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting
{
    public class GetConversionDetailTransactions
    {
        public static ReportingV3ConversionDetailsGet200Response Run()
        {
            var startTime = DateTime.ParseExact("2023-01-21T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact("2023-01-21T23:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new ConversionDetailsApi(clientConfig);
                ReportingV3ConversionDetailsGet200Response result = apiInstance.GetConversionDetail(startTime, endTime, organizationId);
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
