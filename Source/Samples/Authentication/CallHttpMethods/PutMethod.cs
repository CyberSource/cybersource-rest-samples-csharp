//using System;
//using System.IO;
//using ApiSdk.controller;
//using AuthenticationSdk.core;
//using AuthenticationSdk.util;
//using SampleCode.data;

//namespace Cybersource_rest_samples_dotnet.Samples.Authentication
//{
//    public class PutMethod
//    {
        // PUT Request to Create Report Subscription for a report name by organization
        // Report Details provided in the JSON File are sent along with the Request as Request Body
        // Below request subscribes 'TRR Report' for Organization ID: testrest
        //private const string RequestTarget = "/reporting/v2/reportSubscriptions/TRRReport?organizationId=testrest";
        //private static string RequestJsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Source/Resource/TRRReport.json");

        //public static void WriteLogAudit(int status)
        //{
        //    var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
        //    var filename = filePath[filePath.Length - 1];
        //    Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        //}

        //public static void Run()
        //{
        //    try
        //    {
                // Setting up Merchant Config
                //var requestData = new RequestData();

                //var merchantConfig = new MerchantConfig
                //{
                //    RequestTarget = RequestTarget,
                //    RequestType = Enumerations.RequestType.PUT.ToString(),
                //    RequestJsonData = requestData.JsonFileData(RequestJsonFilePath)
                //};

                // Call to the Controller of API_SDK
                //var apiController = new APIController(merchantConfig);
                //var response = apiController.PutPayment();

                // printing the response details
//                if (response != null)
//                {
//                    Console.WriteLine("\n v-c-correlation-id:{0}", response.GetResponseHeaderValue(response.Headers, "v-c-correlation-id"));
//                    Console.WriteLine("\n Response Code:{0}", response.StatusCode);
//                    Console.WriteLine("\n Response Message:{0}", response.Data);
//                    WriteLogAudit(response.StatusCode);
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