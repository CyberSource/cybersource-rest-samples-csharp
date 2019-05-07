using System;
using CyberSource.Api;
using System.Globalization;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetConversionDetailTransactions
    {
        public static void Run()
        {
            DateTime startTime = DateTime.ParseExact("2019-03-21T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact("2019-03-21T23:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ConversionDetailsApi(clientConfig);
                var organizationId = "testrest";

                var result = apiInstance.GetConversionDetail(startTime, endTime, organizationId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
