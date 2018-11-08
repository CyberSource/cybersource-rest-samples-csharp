using System;
using System.Globalization;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.SecureFileShare.CoreServices
{
    public class GetListOfFiles
    {
        public static void Run()
        {
            try
            {
                var startDate ="2018-10-20";
                var endDate = "2018-10-30";
                var organizationId = "testrest";

                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new SecureFileShareApi(clientConfig);
                var result = apiInstance.GetFileDetails(startDate, endDate, organizationId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
