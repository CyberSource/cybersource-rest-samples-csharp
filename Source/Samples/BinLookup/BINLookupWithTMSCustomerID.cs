using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.BinLookup
{
	public class BINLookupWithTMSCustomerID
	{
		public static void WriteLogAudit(int status)
		{
			var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
			var filename = filePath[filePath.Length - 1];
			Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
		}
		public static InlineResponse2012 Run()
		{
			string paymentInformationCustomerId = "E5426CFDE77F7390E053A2598D0A925D";
			GetAllSubscriptionsResponsePaymentInformationCustomer paymentInformationCustomer = new GetAllSubscriptionsResponsePaymentInformationCustomer(
				Id: paymentInformationCustomerId
			);

			Binv1binlookupPaymentInformation paymentInformation = new Binv1binlookupPaymentInformation(
				Customer: paymentInformationCustomer
			);

			var requestObj = new CreateBinLookupRequest(
				PaymentInformation: paymentInformation
			);

			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BinLookupApi(clientConfig);
				InlineResponse2012 result= apiInstance.GetAccountInfo(requestObj);
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