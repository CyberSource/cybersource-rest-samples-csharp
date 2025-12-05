//using System;
//using ApiSdk.controller;
//using AuthenticationSdk.core;
//using AuthenticationSdk.util;

//namespace Cybersource_rest_samples_dotnet.Samples.Authentication
//{
//    public class DeleteMethod
//    {
//        // DELETE Request to Delete subscription of (Unsubscribe) a report name by organization
//        // Below request unsubscribes 'TRR Report' Subscription for Organization ID: testrest
//        private const string RequestTarget = "/reporting/v2/reportSubscriptions/TRRReport?organizationId=testrest";

//        public static void WriteLogAudit(int status)
//        {
//            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
//            var filename = filePath[filePath.Length - 1];
//            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
//        }

//        public static void Run()
//        {
//            try
//            {
//                // Setting up Merchant Config
//                var merchantConfig = new MerchantConfig
//                {
//                    RequestTarget = RequestTarget,
//                    RequestType = Enumerations.RequestType.DELETE.ToString()
//                };

//                // Call to the Controller of API_SDK
//                var apiController = new APIController(merchantConfig);
//                var response = apiController.DeletePayment();

//                // printing the response details
//                if (response != null)
//                {
//                    Console.WriteLine("\n v-c-correlation-id:{0}", response.GetResponseHeaderValue(response.Headers, "v-c-correlation-id"));
//                    Console.WriteLine("\n Response Code:{0}", response.StatusCode);
//                    Console.WriteLine("\n Response Message:{0}", response.Data);
//                    if (response.StatusCode == 200 || response.StatusCode == 404)
//                    {
//                        WriteLogAudit(200);
//                    }
//                    else
//                    {
//                        WriteLogAudit(response.StatusCode);
//                    }
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.StackTrace);
//            }
//        }
//    }
//}
