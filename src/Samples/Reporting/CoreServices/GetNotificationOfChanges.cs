using System;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetNotificationOfChanges
    {
        public static void Run()
        {
            var startTime = DateTime.Parse("2018-09-01T12:00:00-05:00");
            var endTime = DateTime.Parse("2018-09-30T12:00:00-05:00");

            //var startTime = DateTime.Parse("2018-09-01T12:00:00.000Z");
            //var endTime = DateTime.Parse("2018-09-30T12:00:00.000Z");

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new NotificationOfChangesApi(clientConfig);

                var result = apiInstance.GetNotificationOfChangeReport(startTime, endTime);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
