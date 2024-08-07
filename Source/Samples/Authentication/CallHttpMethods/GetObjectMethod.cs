﻿using System;
using ApiSdk.controller;
using AuthenticationSdk.core;
using AuthenticationSdk.util;
using SampleCode.data;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class GetObjectMethod
    {
        // GET request to retrieve the payment details of the provided Payment ID
        // Below Request fetches the payment details of payment ID: 5319754772076048103525
        private const string RequestTarget = "/pts/v2/payments/5526478103126428303006";

        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static void Run()
        {
            try
            {
                // Creating a dictionary object which contains the merchant configuration
                var config = new Configuration();

                // Passing the dictionary object to the Merchant Config Constructor to bypass the config set up via App.Config File
                var merchantConfig = new MerchantConfig(config.GetConfiguration())
                {
                    RequestTarget = RequestTarget,
                    RequestType = Enumerations.RequestType.GET.ToString()
                };

                // Call to the Controller of API_SDK
                var apiController = new APIController(merchantConfig);
                var response = apiController.GetPayment();

                // printing the response details
                if (response != null)
                {
                    Console.WriteLine("\n v-c-correlation-id:{0}", response.GetResponseHeaderValue(response.Headers, "v-c-correlation-id"));
                    Console.WriteLine("\n Response Code:{0}", response.StatusCode);
                    Console.WriteLine("\n Response Message:{0}", response.Data);
                    WriteLogAudit(response.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
