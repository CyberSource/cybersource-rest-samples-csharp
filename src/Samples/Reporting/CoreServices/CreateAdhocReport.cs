using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;
using NLog;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class CreateAdhocReport
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(CreateAdhocReport)}");

            Logger logger = LogManager.GetCurrentClassLogger();
            CyberSource.Client.Configuration clientConfig = null;
            ApiResponse<object> result = null;

            var requestObj = new RequestBody1
            {
                ReportDefinitionName = "TransactionRequestClass",
                ReportFields = new List<string>()
                {
                    "Request.RequestID",
                    "Request.TransactionDate",
                    "Request.MerchantID"
                },
                ReportMimeType = RequestBody1.ReportMimeTypeEnum.ApplicationXml,
                ReportName = "testrest_vter9",
                Timezone = "GMT",
                ReportStartTime = DateTime.ParseExact("2018-09-01T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture),
                ReportEndTime = DateTime.ParseExact("2018-09-02T12:00:00Z", "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
            };

            var reportPreferencesObj = new ReportingV3ReportSubscriptionsGet200ResponseReportPreferences()
            {
                SignedAmounts = true,
                FieldNameConvention = ReportingV3ReportSubscriptionsGet200ResponseReportPreferences.FieldNameConventionEnum.SOAPI
            };

            requestObj.ReportPreferences = reportPreferencesObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReportsApi(clientConfig);

                result = apiInstance.CreateReportWithHttpInfo(requestObj);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(CreateAdhocReport)}):{e.Message}");
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
                    logger.Trace($"\nAPI REQUEST BODY:{JsonConvert.SerializeObject(requestObj)}");

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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(CreateAdhocReport)}");
                }
            }
        }
    }
}