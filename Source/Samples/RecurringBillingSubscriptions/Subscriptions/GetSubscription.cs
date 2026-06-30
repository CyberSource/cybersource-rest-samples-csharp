using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class GetSubscription
	{
		public static async System.Threading.Tasks.Task RunAsync()
		{
			try
			{
				var id = (await CreateSubscription.RunAsync()).Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new SubscriptionsApi(clientConfig);
				await apiInstance.GetSubscriptionAsync(id);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}