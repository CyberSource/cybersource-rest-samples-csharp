using System;
using System.Collections.Generic;
using System.Globalization;
using ApiSdk.model;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.RecurringBillingSubscriptions
{
	public class GetPlan
	{
		public static GetPlanResponse Run()
		{
			try
			{
				var planId = CreatePlan.Run().Id;
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new PlansApi(clientConfig);
				var result = apiInstance.GetPlan(planId);
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