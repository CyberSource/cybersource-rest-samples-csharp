using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.AccountUpdater
{
	public class AmexRegistrationInstrumentIdentifierTokenBatch
	{
		public static InlineResponse202 Run()
		{
			string type = "amexRegistration";

			List <Accountupdaterv1batchesIncludedTokens> includedTokens = new List <Accountupdaterv1batchesIncludedTokens>();
			string includedTokensId1 = "7030000000000260224";
			string includedTokensExpirationMonth1 = "12";
			string includedTokensExpirationYear1 = "2020";
			includedTokens.Add(new Accountupdaterv1batchesIncludedTokens(
				Id: includedTokensId1,
				ExpirationMonth: includedTokensExpirationMonth1,
				ExpirationYear: includedTokensExpirationYear1
			));

			string includedTokensId2 = "7030000000000231118";
			string includedTokensExpirationMonth2 = "12";
			string includedTokensExpirationYear2 = "2020";
			includedTokens.Add(new Accountupdaterv1batchesIncludedTokens(
				Id: includedTokensId2,
				ExpirationMonth: includedTokensExpirationMonth2,
				ExpirationYear: includedTokensExpirationYear2
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
