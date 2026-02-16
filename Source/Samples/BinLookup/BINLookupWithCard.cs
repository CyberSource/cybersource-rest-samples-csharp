using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.BinLookup
{
	public class BINLookupWithCard
	{
		public static void WriteLogAudit(int status)
		{
			var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
			var filename = filePath[filePath.Length - 1];
			Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
		}
		public static InlineResponse2013 Run()
		{
			Binv1binlookupClientReferenceInformation clientReferenceInformation = new Binv1binlookupClientReferenceInformation(
			);

			string paymentInformationCardNumber = "4111111111111111";
			Binv1binlookupPaymentInformationCard paymentInformationCard = new Binv1binlookupPaymentInformationCard(
				Number: paymentInformationCardNumber
			);

			Binv1binlookupPaymentInformation paymentInformation = new Binv1binlookupPaymentInformation(
				Card: paymentInformationCard
			);

			var requestObj = new CreateBinLookupRequest(
				ClientReferenceInformation: clientReferenceInformation,
				PaymentInformation: paymentInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BinLookupApi(clientConfig);
				InlineResponse2013 result = apiInstance.GetAccountInfo(requestObj);
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