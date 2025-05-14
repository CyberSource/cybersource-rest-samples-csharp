using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.CreateNewWebhooks
{
	public class CreateWebhookSymmetricKey
	{
		public static void Run()
		{
			string clientRequestAction = "CREATE";
			string keyInformationProvider = "nrtd";
			string keyInformationTenant = "<INSERT ORGANIZATION ID HERE>";
			string keyInformationKeyType = "sharedSecret";
			string keyInformationOrganizationId = "<INSERT ORGANIZATION ID HERE>";
			string vCcorrelationId = null;
			string vCsenderOrganizationId = null;
			string vCpermissions = null;

			Kmsegressv2keyssymKeyInformation keyInformation = new Kmsegressv2keyssymKeyInformation(
				Provider: keyInformationProvider,
				Tenant: keyInformationTenant,
				KeyType: keyInformationKeyType,
				OrganizationId: keyInformationOrganizationId
			);

			var requestObj = new SaveSymEgressKey(
				ClientRequestAction: clientRequestAction,
				KeyInformation: keyInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new CreateNewWebhooksApi(clientConfig);
				apiInstance.SaveSymEgressKey(vCsenderOrganizationId, vCpermissions, vCcorrelationId, requestObj);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}