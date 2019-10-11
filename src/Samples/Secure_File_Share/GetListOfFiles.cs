using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Secure_File_Share
{
    public class GetListOfFiles
    {
        public static V1FileDetailsGet200Response Run()
        {
            var startDate = DateTime.ParseExact("2018-10-20", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("2018-10-30", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string organizationId = "testrest";
            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new SecureFileShareApi(clientConfig);
                V1FileDetailsGet200Response result = apiInstance.GetFileDetail(startDate, endDate, organizationId);
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
