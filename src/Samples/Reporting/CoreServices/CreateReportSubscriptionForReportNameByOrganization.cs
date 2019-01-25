using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class CreateReportSubscriptionForReportNameByOrganization
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(CreateReportSubscriptionForReportNameByOrganization)}");

            CyberSource.Client.Configuration clientConfig = null;
            ApiResponse<Object> result = null;

            const string reportName = "testrest_subcription_v1";

            var requestObj = new RequestBody(ReportDefinitionName: "TransactionRequestClass",
                ReportFields: new List<string>() { "Request.RequestID", "Request.TransactionDate", "Request.MerchantID" },
                ReportName: reportName)
            {
                ReportMimeType = RequestBody.ReportMimeTypeEnum.ApplicationXml,
                ReportFrequency = "WEEKLY",
                Timezone = "GMT",
                StartTime = "0115",
                StartDay = 1
            };

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportSubscriptionsApi(clientConfig);

                result = apiInstance.CreateSubscriptionWithHttpInfo(string.Empty, requestObj);


                DeleteSubscriptionOfReportNameByOrganization.ReportNameToDelete = reportName;
                DeleteSubscriptionOfReportNameByOrganization.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(CreateReportSubscriptionForReportNameByOrganization)}):{e.Message}");
            }
            finally
            {
                if (clientConfig != null)
                {
                    // PRINTING REQUEST DETAILS
                    if (clientConfig.ApiClient.Configuration.RequestHeaders != null)
                    {
                        Console.WriteLine("\nAPI REQUEST HEADERS:");
                        foreach (var requestHeader in clientConfig.ApiClient.Configuration.RequestHeaders)
                        {
                            Console.WriteLine(requestHeader);
                        }
                    }

                    Console.WriteLine("\nAPI REQUEST BODY:");
                    Console.WriteLine(JsonConvert.SerializeObject(requestObj));

                    // PRINTING RESPONSE DETAILS
                    if (clientConfig.ApiClient.ApiResponse != null)
                    {
                        if (!string.IsNullOrEmpty(clientConfig.ApiClient.ApiResponse.StatusCode.ToString()))
                        {
                            Console.WriteLine($"\nAPI RESPONSE CODE: {clientConfig.ApiClient.ApiResponse.StatusCode}");
                        }

                        Console.WriteLine("\nAPI RESPONSE HEADERS:");

                        foreach (var responseHeader in clientConfig.ApiClient.ApiResponse.HeadersList)
                        {
                            Console.WriteLine(responseHeader);
                        }

                        Console.WriteLine("\nAPI RESPONSE BODY:");
                        Console.WriteLine(clientConfig.ApiClient.ApiResponse.Data);
                    }

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(CreateReportSubscriptionForReportNameByOrganization)}");
                }
            }
        }
    }
}