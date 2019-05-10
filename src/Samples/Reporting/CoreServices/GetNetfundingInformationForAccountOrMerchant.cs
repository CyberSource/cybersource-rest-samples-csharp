using System;
using System.Globalization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetNetfundingInformationForAccountOrMerchant
    {
        public static void Run()
        {
            try
            {
                var startTime = DateTime.ParseExact("2019-03-21T00:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                var endTime = DateTime.ParseExact("2019-03-21T23:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
                var groupName = "testName";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new NetFundingsApi(clientConfig);

                var result = apiInstance.GetNetFundingDetails(startTime, endTime, organizationId, groupName);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
