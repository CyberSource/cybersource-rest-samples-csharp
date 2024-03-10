using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class ReplaySpecificListOfTransactions
	{
		public static void Run(string webhookId)
		{

			List <string> byTransactionTraceIdentifiers = new List <string>();
			byTransactionTraceIdentifiers.Add("1f1d0bf4-9299-418d-99d8-faa3313829f1");
			byTransactionTraceIdentifiers.Add("d19fb205-20e5-43a2-867e-bd0f574b771e");
			byTransactionTraceIdentifiers.Add("2f2461a3-457c-40e9-867f-aced89662bbb");
			byTransactionTraceIdentifiers.Add("e23ddc19-93d5-4f1f-8482-d7cafbb3ed9b");
			byTransactionTraceIdentifiers.Add("eb9fc4a9-b31f-48d5-81a9-b1d773fd76d8");
			var requestObj = new ReplayWebhooksRequest(
				ByTransactionTraceIdentifiers: byTransactionTraceIdentifiers
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new ManageWebhooksApi(clientConfig);
				apiInstance.ReplayPreviousWebhooks(webhookId, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}