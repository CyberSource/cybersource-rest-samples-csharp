using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.SecureFileShare
{
    public class GetListOfFiles
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static V1FileDetailsGet200Response Run()
        {
            var startDate = DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("2020-07-30", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string organizationId = "testrest";
            string name = null;
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new SecureFileShareApi(clientConfig);
                V1FileDetailsGet200Response result = apiInstance.GetFileDetail(startDate, endDate, organizationId, name);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
