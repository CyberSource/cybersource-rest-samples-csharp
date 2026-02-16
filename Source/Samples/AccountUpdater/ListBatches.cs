using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.AccountUpdater
{
	public class ListBatches
	{
		public static void Run()
		{
			try
			{
				var configDictionary = new Configuration().GetConfiguration();
				var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

				var apiInstance = new BatchesApi(clientConfig);
				string fromDate = "20230101T123000Z";
				string toDate = "20230410T123000Z";
				InlineResponse20012 result = apiInstance.GetBatchesList(0, 10, fromDate, toDate);
                Console.WriteLine(result);
            }
			catch (Exception e)
			{
				Console.WriteLine("Exception on calling the API : " + e.Message);
			}
		}
	}
}
