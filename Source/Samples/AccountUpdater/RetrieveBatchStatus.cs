using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.AccountUpdater
{
	public class RetrieveBatchStatus
	{
		public static void Run()
		{
			try
			{
				string batchId = "16188390061150001062041064";

                var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BatchesApi(clientConfig);
				InlineResponse20011 result = apiInstance.GetBatchStatus(batchId);
				Console.WriteLine(result);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}
