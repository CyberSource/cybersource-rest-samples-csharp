﻿using System;
using CyberSource.Api;
using CyberSource.Client;

namespace Cybersource_rest_samples_dotnet.Samples.Reporting.CoreServices
{
    public class GetPurchaseAndRefundDetails
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(GetPurchaseAndRefundDetails)}");

            CyberSource.Client.Configuration clientConfig = null;
            ApiResponse<object> result = null;

            const string organizationId = "testrest";
            var startTime = DateTime.Parse("2018-05-01T12:00:00-05:00");
            var endTime = DateTime.Parse("2018-05-30T12:00:00-05:00");
            const string paymentSubtype = "VI";
            const string viewBy = "requestDate";
            const string groupName = "groupName";
            const int offset = 20;
            const int limit = 2000;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PurchaseAndRefundDetailsApi(clientConfig);

                result = apiInstance.GetPurchaseAndRefundDetailsWithHttpInfo(startTime, endTime, organizationId, paymentSubtype,
                    viewBy, groupName, offset, limit);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(GetPurchaseAndRefundDetails)}):{e.Message}");
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(GetPurchaseAndRefundDetails)}");
                }
            }
        }
    }
}