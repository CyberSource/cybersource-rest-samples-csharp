using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetPurchaseAndRefundDetails
    {
        public static void Run()
        {
            const string organizationId = "testrest";
            var startTime = DateTime.Parse("2018-05-01T12:00:00-05:00");
            var endTime = DateTime.Parse("2018-05-30T12:00:00-05:00");
            const string paymentSubtype = "VI";
            const string viewBy = "requestDate";
            const string groupName = "groupName";
            const int offset = 20;
            const int limit = 2000;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PurchaseAndRefundDetailsApi(clientConfig);

                var result = apiInstance.GetPurchaseAndRefundDetails(startTime, endTime, organizationId, paymentSubtype,
                    viewBy, groupName, offset, limit);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
