//using System;
//using SampleCode.data;

//namespace Cybersource_rest_samples_dotnet.Samples.Authentication
//{
//    public class PostObjectMethod
//    {
//        // POST Request to Authorize the payment for a transaction. 
//        // Transaction details are sent along with the Request as Request Body
//        private const string RequestTarget = "/pts/v2/payments/";

//        public static void Run()
//        {
//            try
//            {
//                // Setting up Merchant Config 
//                var config = new Configuration();

//                // Setting RequestJson Data using the sample payments data (instead of reading a JSON file)
//                var requestData = new RequestData();

//                var merchantConfig = new MerchantConfig(config.GetConfiguration())
//                {
//                    RequestTarget = RequestTarget,
//                    RequestType = Enumerations.RequestType.POST.ToString(),
//                    RequestJsonData = requestData.SamplePaymentsData()
//                };

//                // Call to the Controller of API_SDK   
//                var apiController = new APIController(merchantConfig);
//                var response = apiController.PostPayment();

//                // printing the response details
//                if (response != null)
//                {
//                    Console.WriteLine("\n v-c-correlation-id:{0}", response.GetResponseHeaderValue(response.Headers, "v-c-correlation-id"));
//                    Console.WriteLine("\n Response Code:{0}", response.StatusCode);
//                    Console.WriteLine("\n Response Message:{0}", response.Data);
//                }
//            }
//            catch (Exception e)
//            {
//                ExceptionUtility.Exception(e.Message, e.StackTrace);
//            }
//        }
//    }
//}