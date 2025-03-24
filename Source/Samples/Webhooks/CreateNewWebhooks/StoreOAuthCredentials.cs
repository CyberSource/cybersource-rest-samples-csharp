using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.CreateNewWebhooks
{
	public class StoreOAuthCredentials
	{
		public static void Run()
		{
			string clientRequestAction = "STORE";
			string keyInformationProvider = "<INSERT ORGANIZATION ID HERE>";
			string keyInformationTenant = "nrtd";
			string keyInformationKeyType = "oAuthClientCredentials";
			string keyInformationOrganizationId = "<INSERT ORGANIZATION ID HERE>";
			string keyInformationClientKeyId = "client username";
			string keyInformationKey = "client secret";
			string keyInformationExpiryDuration = "365";
            string vCcorrelationId = null;
            string vCsenderOrganizationId = null;
            string vCpermissions = null;

			Kmsegressv2keyssymKeyInformation keyInformation = new Kmsegressv2keyssymKeyInformation(
				Provider: keyInformationProvider,
				Tenant: keyInformationTenant,
				KeyType: keyInformationKeyType,
				OrganizationId: keyInformationOrganizationId,
				ClientKeyId: keyInformationClientKeyId,
				Key: keyInformationKey,
				ExpiryDuration: keyInformationExpiryDuration
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