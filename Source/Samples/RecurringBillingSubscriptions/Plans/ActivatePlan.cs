using CyberSource.Api;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
    public class ActivatePlan
    {
        public static async System.Threading.Tasks.Task<ActivateDeactivatePlanResponse> RunAsync()
        {
            try
            {
                var planId = (await CreatePlan.RunAsync()).Id;
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PlansApi(clientConfig);
                var result = await apiInstance.ActivatePlanAsync(planId);
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
