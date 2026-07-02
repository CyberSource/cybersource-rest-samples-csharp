using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class GetPlan
	{
		public static async System.Threading.Tasks.Task<GetPlanResponse> RunAsync()
		{
			try
			{
				var planId = (await CreatePlan.RunAsync()).Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PlansApi(clientConfig);
				var result = await apiInstance.GetPlanAsync(planId);
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