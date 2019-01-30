using System;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;
using NLog;

namespace Cybersource_rest_samples_dotnet.Samples.Payouts.CoreServices
{
    public class ProcessPayout
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(ProcessPayout)}");

            Logger logger = LogManager.GetCurrentClassLogger();
            CyberSource.Client.Configuration clientConfig = null;
            ApiResponse<object> result = null;

            var requestObj = new PtsV2PayoutsPostResponse();

            var clientReferenceInformationObj = new PtsV2PaymentsPost201ResponseClientReferenceInformation
            {
                Code = "33557799"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var senderInformationObj = new Ptsv2payoutsSenderInformation
            {
                ReferenceNumber = "1234567890",
                Address1 = "900 Metro Center Blvd.900",
                CountryCode = "US",
                Locality = "San Francisco",
                Name = "Thomas Jefferson",
                AdministrativeArea = "CA"
            };

            var accountObj = new Ptsv2payoutsSenderInformationAccount
            {
                Number = "1234567890123456789012345678901234",
                FundsSource = "01"
            };

            senderInformationObj.Account = accountObj;

            requestObj.SenderInformation = senderInformationObj;

            var processingInformationObj = new Ptsv2payoutsProcessingInformation
            {
                CommerceIndicator = "internet",
                BusinessApplicationId = "FD",
                NetworkRoutingOrder = "ECG"
            };

            requestObj.ProcessingInformation = processingInformationObj;

            var orderInformationObj = new Ptsv2payoutsOrderInformation();

            var amountDetailsObj = new Ptsv2payoutsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            var merchantInformationObj = new Ptsv2payoutsMerchantInformation
            {
                CategoryCode = 123
            };

            var merchantDescriptorObj = new Ptsv2payoutsMerchantInformationMerchantDescriptor
            {
                Country = "US",
                PostalCode = "94440",
                Locality = "FC",
                Name = "Thomas",
                AdministrativeArea = "CA"
            };

            merchantInformationObj.MerchantDescriptor = merchantDescriptorObj;

            requestObj.MerchantInformation = merchantInformationObj;

            var paymentInformationObj = new Ptsv2payoutsPaymentInformation();

            var cardObj = new Ptsv2payoutsPaymentInformationCard
            {
                ExpirationYear = "2025",
                Number = "4111111111111111",
                ExpirationMonth = "12",
                Type = "001",
                SourceAccountType = "CH"
            };

            paymentInformationObj.Card = cardObj;

            requestObj.PaymentInformation = paymentInformationObj;

            var recipientInformationObj = new Ptsv2payoutsRecipientInformation
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "Paseo Padre Boulevard",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                PostalCode = "94400",
                PhoneNumber = "6504320556",
                DateOfBirth = "19801009",
                Country = "US"
            };

            requestObj.RecipientInformation = recipientInformationObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new ProcessAPayoutApi(clientConfig);

                result = apiInstance.OctCreatePaymentWithHttpInfo(requestObj);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(ProcessPayout)}):{e.Message}");
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
                    logger.Trace($"\nAPI REQUEST BODY:{JsonConvert.SerializeObject(requestObj)}");

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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(ProcessPayout)}");
                }
            }
        }
    }
}