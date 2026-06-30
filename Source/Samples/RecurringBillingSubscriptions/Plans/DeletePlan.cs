using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class DeletePlan
	{
		public static async System.Threading.Tasks.Task RunAsync()
		{
			try
			{
				var id = (await CreatePlan.RunAsync()).Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PlansApi(clientConfig);
				await apiInstance.DeletePlanAsync(id);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}