using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class ReplayFailedTransactionsBySetStartAndEndTime
	{
		public static void Run(string webhookId)
		{
			string byDeliveryStatusStatus = "FAILED";
			var byDeliveryStatusStartTime = DateTime.Parse("2021-01-01T15:05:52.284+05:30");
			var byDeliveryStatusEndTime = DateTime.Parse("2021-01-02T03:05:52.284+05:30");
			string byDeliveryStatusProductId = "tokenManagement";
			string byDeliveryStatusEventType = "tms.token.created";
			Nrtfv1webhookswebhookIdreplaysByDeliveryStatus byDeliveryStatus = new Nrtfv1webhookswebhookIdreplaysByDeliveryStatus(
				Status: byDeliveryStatusStatus,
				StartTime: byDeliveryStatusStartTime,
				EndTime: byDeliveryStatusEndTime,
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