using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RefundCapture
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(RefundCapture)}");

            var capturePaymentId = CapturePayment.Run().Id;

            CyberSource.Client.Configuration clientConfig = null;
            PtsV2PaymentsRefundPost201Response result = null;

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation("test_refund_capture");
            var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails("102.21", "USD");
            var orderInformationObj = new Ptsv2paymentsidrefundsOrderInformation(amountDetailsObj);
            var requestObj = new RefundCaptureRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new RefundApi(clientConfig);

                result = apiInstance.RefundCapture(requestObj, capturePaymentId);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(RefundCapture)}):{e.Message}");
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

                    if (!string.IsNullOrEmpty(clientConfig.ApiClient.Configuration.RequestBody))
                    {
                        Console.WriteLine("\nAPI REQUEST BODY:");
                        Console.WriteLine(clientConfig.ApiClient.Configuration.RequestBody);
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(RefundCapture)}");
                }
            }
        }
    }
}