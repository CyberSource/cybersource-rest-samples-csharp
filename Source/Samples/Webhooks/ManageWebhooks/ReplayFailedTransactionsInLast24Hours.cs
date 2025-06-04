using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class ReplayFailedTransactionsInLast24Hours
	{
		public static void Run()
		{
			/*string webhookId = "";
			string byDeliveryStatusStatus = "FAILED";
			int byDeliveryStatusHoursBack = 24;
			string byDeliveryStatusProductId = "tokenManagement";
			string byDeliveryStatusEventType = "tms.token.created";
			Nrtfv1webhookswebhookIdreplaysByDeliveryStatus byDeliveryStatus = new Nrtfv1webhookswebhookIdreplaysByDeliveryStatus(
				Status: byDeliveryStatusStatus,
				HoursBack: byDeliveryStatusHoursBack,
				ProductId: byDeliveryStatusProductId,
				EventType: byDeliveryStatusEventType
			);

			var requestObj = new ReplayWebhooksRequest(
				ByDeliveryStatus: byDeliveryStatus
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new ReplayWebhooksApi(clientConfig);
				apiInstance.ReplayPreviousWebhooks(webhookId, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}*/
		}
	}
}