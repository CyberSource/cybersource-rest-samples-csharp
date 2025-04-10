using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.BinLookup
{
	public class BINLookupWithTMSJtiTransientToken
	{
		public static void WriteLogAudit(int status)
		{
			var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
			var filename = filePath[filePath.Length - 1];
			Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
		}
		public static InlineResponse2011 Run()
		{
			string tokenInformationJti = "1E0WC1GO87JG1BDP0CQ8SCR1TTK86U9N98H3WH8IFM9MVEWTIYFI62F4941E7A92";
			Binv1binlookupTokenInformation tokenInformation = new Binv1binlookupTokenInformation(
				Jti: tokenInformationJti
			);

			var requestObj = new CreateBinLookupRequest(
				TokenInformation: tokenInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BinLookupApi(clientConfig);
				InlineResponse2011 result = apiInstance.GetAccountInfo(requestObj);
				Console.WriteLine(result);
				WriteLogAudit(apiInstance.GetStatusCode());
				return result;
			}
			catch (ApiException e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
				WriteLogAudit(e.ErrorCode);
				return null;
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
				WriteLogAudit(999);
				return null;
			}
		}
	}
}