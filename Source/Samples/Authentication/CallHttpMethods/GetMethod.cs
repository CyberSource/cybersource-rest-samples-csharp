using System;
using ApiSdk.controller;
using AuthenticationSdk.core;
using AuthenticationSdk.util;

namespace Cybersource_rest_samples_dotnet.Samples.Authentication
{
    public class GetMethod
    {
        // GET request to retrieve the payment details of the provided Payment ID
        // Below Request fetches the payment details of payment ID: 5319754772076048103525
        private const string RequestTarget = "/pts/v2/payments/5526383152166546003003";

        public static void Run()
        {
            try
            {
                // Setting up Merchant Config
                var merchantConfig = new MerchantConfig
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
                }
            }
            catch (Exception e)
            {
                ExceptionUtility.Exception(e.Message, e.StackTrace);
            }
        }
    }
}