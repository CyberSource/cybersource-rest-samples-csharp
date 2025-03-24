using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class UpdateWebhook
	{
		public static void Run()
		{
			string webhookId = "";
			string name = "My Sample Webhook";
			string description = "Update to my sample webhook";
			string organizationId = "<INSERT ORGANIZATION ID HERE>";
			string productId = "terminalManagement";

			List <string> eventTypes = new List <string>();
			eventTypes.Add("terminalManagement.assignment.update");
			eventTypes.Add("terminalManagement.status.update");
			string webhookUrl = "https://MyWebhookServer.com:8443:/simulateClient";
			string healthCheckUrl = "https://MyWebhookServer.com:8443:/simulateClientHealthCheck";
			string status = "INACTIVE";
			string notificationScopeScope = "SELF";
			Notificationsubscriptionsv1webhooksNotificationScope notificationScope = new Notificationsubscriptionsv1webhooksNotificationScope(
				Scope: notificationScopeScope
			);

			var requestObj = new UpdateWebhookRequest(
				Name: name,
				Description: description,
				OrganizationId: organizationId,
				ProductId: productId,
				EventTypes: eventTypes,
				WebhookUrl: webhookUrl,
				HealthCheckUrl: healthCheckUrl,
				Status: status,
				NotificationScope: notificationScope
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new ManageWebhooksApi(clientConfig);
				apiInstance.UpdateWebhookSubscription(webhookId, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}