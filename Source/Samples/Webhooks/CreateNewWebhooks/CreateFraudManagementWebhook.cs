using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.CreateNewWebhooks
{
	public class CreateFraudManagementWebhook
	{
		public static void Run()
		{
			/*string name = "My Custom Webhook";
			string description = "Sample Webhook from Developer Center";
			string organizationId = "<INSERT ORGANIZATION ID HERE>";
			string productId = "fraudManagementEssentials";

			List <string> eventTypes = new List <string>();
			eventTypes.Add("risk.profile.decision.review");
			eventTypes.Add("risk.profile.decision.reject");
			eventTypes.Add("risk.profile.decision.monitor");
			eventTypes.Add("risk.casemanagement.addnote");
			eventTypes.Add("risk.casemanagement.decision.accept");
			eventTypes.Add("risk.casemanagement.decision.reject");
			string webhookUrl = "https://MyWebhookServer.com:8443/simulateClient";
			string healthCheckUrl = "https://MyWebhookServer.com:8443/simulateClientHealthCheck";
			string notificationScope = "SELF";
			string retryPolicyAlgorithm = "ARITHMETIC";
			int retryPolicyFirstRetry = 1;
			int retryPolicyInterval = 1;
			int retryPolicyNumberOfRetries = 3;
			string retryPolicyDeactivateFlag = "false";
			int retryPolicyRepeatSequenceCount = 0;
			int retryPolicyRepeatSequenceWaitTime = 0;
			Notificationsubscriptionsv1webhooksRetryPolicy retryPolicy = new Notificationsubscriptionsv1webhooksRetryPolicy(
				Algorithm: retryPolicyAlgorithm,
				FirstRetry: retryPolicyFirstRetry,
				Interval: retryPolicyInterval,
				NumberOfRetries: retryPolicyNumberOfRetries,
				DeactivateFlag: retryPolicyDeactivateFlag,
				RepeatSequenceCount: retryPolicyRepeatSequenceCount,
				RepeatSequenceWaitTime: retryPolicyRepeatSequenceWaitTime
			);

			string securityPolicySecurityType = "KEY";
			string securityPolicyProxyType = "external";
			Notificationsubscriptionsv1webhooksSecurityPolicy1 securityPolicy = new Notificationsubscriptionsv1webhooksSecurityPolicy1(
				SecurityType: securityPolicySecurityType,
				ProxyType: securityPolicyProxyType
			);

			var requestObj = new CreateWebhookRequest(
				Name: name,
				Description: description,
				OrganizationId: organizationId,
				ProductId: productId,
				EventTypes: eventTypes,
				WebhookUrl: webhookUrl,
				HealthCheckUrl: healthCheckUrl,
				NotificationScope: notificationScope,
				RetryPolicy: retryPolicy,
				SecurityPolicy: securityPolicy
			);*/

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new CreateNewWebhooksApi(clientConfig);
				//apiInstance.CreateWebhookSubscription(requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}