using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.BinLookup
{
	public class BINLookupWithTMSJWTTransientToken
	{
		public static void WriteLogAudit(int status)
		{
			var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
			var filename = filePath[filePath.Length - 1];
			Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
		}
		public static InlineResponse2011 Run()
		{
			string tokenInformationTransientTokenJwt = "eyJraWQiOiIwODd0bk1DNU04bXJHR3JHMVJQTkwzZ2VyRUh5VWV1ciIsImFsZyI6IlJTMjU2In0.eyJpc3MiOiJGbGV4LzA4IiwiZXhwIjoxNjYwMTk1ODcwLCJ0eXBlIjoiYXBpLTAuMS4wIiwiaWF0IjoxNjYwMTk0OTcwLCJqdGkiOiIxRTBXQzFHTzg3SkcxQkRQMENROFNDUjFUVEs4NlU5Tjk4SDNXSDhJRk05TVZFV1RJWUZJNjJGNDk0MUU3QTkyIiwiY29udGVudCI6eyJwYXltZW50SW5mb3JtYXRpb24iOnsiY2FyZCI6eyJudW1iZXIiOnsibWFza2VkVmFsdWUiOiJYWFhYWFhYWFhYWFgxMTExIiwiYmluIjoiNDExMTExIn0sInR5cGUiOnsidmFsdWUiOiIwMDEifX19fX0.MkCLbyvufN4prGRvHJcqCu1WceDVlgubZVpShNWQVjpuFQUuqwrKg284sC7ucVKuIsOU0DTN8_OoxDLduvZhS7X_5TnO0QjyA_aFxbRBvU_bEz1l9V99VPADG89T-fox_L6sLUaoTJ8T4PyD7rkPHEA0nmXbqQCVqw4Czc5TqlKCwmL-Fe0NBR2HlOFI1PrSXT-7_wI-JTgXI0dQzb8Ub20erHwOLwu3oni4_ZmS3rGI_gxq2MHi8pO-ZOgA597be4WfVFAx1wnMbareqR72a0QM4DefeoltrpNqXSaASVyb5G0zuqg-BOjWJbawmg2QgcZ_vE3rJ6PDgWROvp9Tbw";
			Binv1binlookupTokenInformation tokenInformation = new Binv1binlookupTokenInformation(
				TransientTokenJwt: tokenInformationTransientTokenJwt
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