using System;
using CyberSource.Api;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class CapturePayment
    {
        public static PtsV2PaymentsCapturesPost201Response Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(CapturePayment)}");

            var processPaymentId = ProcessPayment.Run().Id;

            CyberSource.Client.Configuration clientConfig = null;
            PtsV2PaymentsCapturesPost201Response result = null;

            var requestObj = new CapturePaymentRequest();

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation
            {
                Code = "test_capture"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var pointOfSaleInformationObj = new Ptsv2paymentsidcapturesPointOfSaleInformation
            {
                CardPresent = false,
                CatLevel = "6",
                TerminalCapability = "4"
            };

            requestObj.PointOfSaleInformation = pointOfSaleInformationObj;

            var orderInformationObj = new Ptsv2paymentsidcapturesOrderInformation();

            var billToObj = new Ptsv2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Doe",
                Address1 = "1 Market St",
                PostalCode = "94105",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "102.21",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new CaptureApi(clientConfig);

                result = apiInstance.CapturePayment(requestObj, processPaymentId);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(CapturePayment)}):{e.Message}");
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(CapturePayment)}");
                }
            }
        }
    }
}
