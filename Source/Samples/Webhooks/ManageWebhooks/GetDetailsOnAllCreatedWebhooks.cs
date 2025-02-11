using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class GetDetailsOnAllCreatedWebhooks
	{
		public static List<InlineResponse2003> Run()
		{
			// QUERY PARAMETERS
			string organizationId = "testrest";
			string productId = "testProductId";
			string eventType = "testEventType";
			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new ManageWebhooksApi(clientConfig);
				List<InlineResponse2003> result = apiInstance.GetWebhookSubscriptionsByOrg(organizationId, productId, eventType);
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