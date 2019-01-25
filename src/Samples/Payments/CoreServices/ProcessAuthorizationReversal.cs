using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class ProcessAuthorizationReversal
    {
        public static PtsV2PaymentsReversalsPost201Response Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(ProcessAuthorizationReversal)}");

            var processPaymentId = ProcessPayment.Run().Id;

            CyberSource.Client.Configuration clientConfig = null;
            PtsV2PaymentsReversalsPost201Response result = null;

            var clientReferenceInformationObj = new Ptsv2paymentsidreversalsClientReferenceInformation("test_reversal");
            var amount = new Ptsv2paymentsidreversalsOrderInformationLineItems(null, "102.21");
            var amountDetailsObj = new List<Ptsv2paymentsidreversalsOrderInformationLineItems> { amount };
            var orderInformationObj = new Ptsv2paymentsidreversalsOrderInformation(amountDetailsObj);
            var requestObj = new AuthReversalRequest(clientReferenceInformationObj, null, null, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ReversalApi(clientConfig);

                result = apiInstance.AuthReversal(processPaymentId, requestObj);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(ProcessAuthorizationReversal)}):{e.Message}");
                return null;
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(ProcessAuthorizationReversal)}");
                }
            }
        }
    }
}
