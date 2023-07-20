using CyberSource.Api;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
    public class GetListOfPlans
    {
        public static InlineResponse200 Run()
        {
            int? offset = (int?)null;
            int? limit = (int?)null;
            string code = null;
            string status = null;
            string name = null;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PlansApi(clientConfig);
                var result = apiInstance.GetPlans(offset, limit, code, status, name);
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
