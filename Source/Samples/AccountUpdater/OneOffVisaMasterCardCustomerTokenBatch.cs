using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.AccountUpdater
{
	public class OneOffVisaMasterCardCustomerTokenBatch
	{
		public static InlineResponse202 Run()
		{
			string type = "oneOff";

			List <Accountupdaterv1batchesIncludedTokens> includedTokens = new List <Accountupdaterv1batchesIncludedTokens>();
			string includedTokensId1 = "C064DE56200B0DB0E053AF598E0A52AA";
			includedTokens.Add(new Accountupdaterv1batchesIncludedTokens(
				Id: includedTokensId1
			));

			string includedTokensId2 = "C064DE56213D0DB0E053AF598E0A52AA";
			includedTokens.Add(new Accountupdaterv1batchesIncludedTokens(
				Id: includedTokensId2
			));

			Accountupdaterv1batchesIncluded included = new Accountupdaterv1batchesIncluded(
				Tokens: includedTokens
			);

			string merchantReference = "TC50171_3";
			string notificationEmail = "test@cybs.com";
			var requestObj = new Body(
				Type: type,
				Included: included,
				MerchantReference: merchantReference,
				NotificationEmail: notificationEmail
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BatchesApi(clientConfig);
                InlineResponse202 result = apiInstance.PostBatch(requestObj);
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
