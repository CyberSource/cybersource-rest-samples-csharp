using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.BinLookup
{
	public class BINLookupWithTMSInstrumentIdentifier
	{
		public static void WriteLogAudit(int status)
		{
			var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
			var filename = filePath[filePath.Length - 1];
			Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
		}
		public static InlineResponse2011 Run()
		{
			string paymentInformationInstrumentIdentifierId = "7010000000016241111";
			Ptsv2paymentsPaymentInformationInstrumentIdentifier paymentInformationInstrumentIdentifier = new Ptsv2paymentsPaymentInformationInstrumentIdentifier(
				Id: paymentInformationInstrumentIdentifierId
			);

			Binv1binlookupPaymentInformation paymentInformation = new Binv1binlookupPaymentInformation(
				InstrumentIdentifier: paymentInformationInstrumentIdentifier
			);

			var requestObj = new CreateBinLookupRequest(
				PaymentInformation: paymentInformation
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