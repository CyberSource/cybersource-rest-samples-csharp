//using System;
//using AuthenticationSdk.core;
//using AuthenticationSdk.util;

//namespace Cybersource_rest_samples_dotnet.Samples.Authentication
//{
//    public class DeleteGenerateHeaders
//    {
        // DELETE Request to Delete subscription of (Unsubscribe) a report name by organization 
        // Below request unsubscribes 'TRR Report' Subscription for Organization ID: testrest
      //  private const string RequestTarget = "/reporting/v2/reportSubscriptions/TRRReport?organizationId=testrest";

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
                //var merchantConfig = new MerchantConfig
                //{
                //    RequestTarget = RequestTarget,
                //    RequestType = Enumerations.RequestType.DELETE.ToString(),
                //};

                // Call to the Authorize class of AuthSDK to get the signature and token objects
//                var authorizeObj = new Authorize(merchantConfig);

//                if (string.Equals(merchantConfig.AuthenticationType, Enumerations.AuthenticationType.HTTP_SIGNATURE.ToString(), StringComparison.OrdinalIgnoreCase))
//                {
//                    var requestHeaders = authorizeObj.GetSignature();

//                    Console.WriteLine("{0} {1}", "Accept:", "application/hal+json");
//                    Console.WriteLine("{0} {1}", "v-c-merchant-id:", requestHeaders.MerchantId);
//                    Console.WriteLine("{0} {1}", "Date:", requestHeaders.GmtDateTime);
//                    Console.WriteLine("{0} {1}", "Host:", requestHeaders.HostName);
//                    Console.WriteLine("{0} {1}", "signature:", requestHeaders.SignatureParam);
//                    WriteLogAudit(200);
//                }
//                else if (string.Equals(merchantConfig.AuthenticationType, Enumerations.AuthenticationType.JWT.ToString(), StringComparison.OrdinalIgnoreCase))
//                {
//                    var requestHeaders = authorizeObj.GetToken();

//                    Console.WriteLine("{0} {1}", "Accept:", "application/hal+json");
//                    Console.WriteLine("{0} {1}", "Authorization:", requestHeaders.BearerToken);
//                    WriteLogAudit(200);
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                Console.WriteLine(e.StackTrace);
//                WriteLogAudit(400);
//            }
//        }
//    }
//}
