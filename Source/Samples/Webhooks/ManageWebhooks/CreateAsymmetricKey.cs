using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Webhooks.ManageWebhooks
{
	public class CreateAsymmetricKey
	{
		public static InlineResponse2015 Run()
		{
			string clientRequestAction = "STORE";
			string keyInformationProvider = "merchantName";
			string keyInformationTenant = "nrtd";
			string keyInformationKeyType = "publickey";
			string keyInformationOrganizationId = "merchantName";
			string keyInformationPub = "MIIDbDCCAlQCCQD4lcSlmasmCTANBgkqhkiG9w0BAQsFADB4MQswCQYDVQQGEwJVUzELMAkGA1UECAwCVFgxDzANBgNVBAcMBkF1c3RpbjENMAsGA1UECgwEVGVzdDEOMAwGA1UECwwFVGVzdDIxDjAMBgNVBAMMBVRlc3QzMRwwGgYJKoZIhvcNAQkBFg10ZXN0QHRlc3QuY29tMB4XDTIxMDgwOTE0MTcxNFoXDTIyMDgwOTE0MTcxNFoweDELMAkGA1UEBhMCVVMxCzAJBgNVBAgMAlRYMQ8wDQYDVQQHDAZBdXN0aW4xDTALBgNVBAoMBFRlc3QxDjAMBgNVBAsMBVRlc3QyMQ4wDAYDVQQDDAVUZXN0MzEcMBoGCSqGSIb3DQEJARYNdGVzdEB0ZXN0LmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBAMcHQWZRETqim3XzUQlAiujFEvsHIi1uJZKj+1lvPH36Ucqo3ORcoh/MM/zxVdahjhSyyp7MHuKBWnzft6bFeDEul6qKWGPAAzaxG/2xZSV3FggA9SyAZEDUpJ6mblwqm/EY4KmZi1FrNBUHfW2wwaqDexHPRDesRG6aI7Wuu4GdQUUqoTa2+Nv7kVgEDmGcfIjoWkGKHe+Yan95EITrq4jEFCE5Tg/vERnMvHfK2SovENZ13/pnwFYbeh1kfJSBzWW7yq8AyQAgAE9iqJXbJ/MAasir2vjUQ2+Hcl7WbkpoVjLqDt3rzV1T0Bsd4T9SC3wij9qjJSxa6vAgV4xn6bECAwEAATANBgkqhkiG9w0BAQsFAAOCAQEADuMrtYW1Sf0IsZ4ZD9ipjUrFuTxqh+0M5Jk8h0QqAXEHA/MawedlU3JmE3NB/UR82/XUwdmtObGnFANuUQQ+8WMFpcNo/Sq2kg7juneHZroRh72o73UUMtHWHzo8s0fXElNal8h3SaAAnjMblCiN+gM1RvWMvhGrMTXp2XAcdIezXf8/FOZLlzOF9QylbSk1U4ayWBag6MydkxgHjkPKdShZROEm0oz/O7J/gNp/r7J8F42Rw9MmJh9qH3SFre13nQa8V7Kg+dJHZ/jpGtSlDHAxO0SSTrPXkwB+iBJ6hSkiL/J2Ep+lYHqVe3p5NXMOlTtJdbU4enHeLkD6PazKTw";
			string keyInformationExpiryDuration = "365";
            string vCcorrelationId = null;
            string vCsenderOrganizationId = null;
            string vCpermissions = null;

			Kmsegressv2keysasymKeyInformation keyInformation = new Kmsegressv2keysasymKeyInformation(
				Provider: keyInformationProvider,
				Tenant: keyInformationTenant,
				KeyType: keyInformationKeyType,
				OrganizationId: keyInformationOrganizationId,
				Pub: keyInformationPub,
				ExpiryDuration: keyInformationExpiryDuration
			);

			var requestObj = new SaveAsymEgressKey(
				ClientRequestAction: clientRequestAction,
				KeyInformation: keyInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new ManageWebhooksApi(clientConfig);
				InlineResponse2015 result = apiInstance.SaveAsymEgressKey(vCsenderOrganizationId, vCpermissions, requestObj, vCcorrelationId);
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