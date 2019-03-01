﻿using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class CreateInstrumentIdentifier
    {
        public static TmsV1InstrumentidentifiersPost200Response Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(CreateInstrumentIdentifier)}");

            CyberSource.Client.Configuration clientConfig = null;
            TmsV1InstrumentidentifiersPost200Response result = null;

            var requestObj = new Body();

            var cardObj = new Tmsv1instrumentidentifiersCard
            {
                Number = "1234567123487456"
            };

            requestObj.Card = cardObj;

            var processingInformationObj = new Tmsv1instrumentidentifiersProcessingInformation();

            var authorizationOptionsObj = new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptions();

            var initiatorObj = new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptionsInitiator();

            var merchantInitiatedTransactionObj =
                new Tmsv1instrumentidentifiersProcessingInformationAuthorizationOptionsInitiatorMerchantInitiatedTransaction
                {
                    PreviousTransactionId = "123456789012345"
                };

            initiatorObj.MerchantInitiatedTransaction = merchantInitiatedTransactionObj;

            authorizationOptionsObj.Initiator = initiatorObj;

            processingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = processingInformationObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new InstrumentIdentifiersApi(clientConfig);

                result = apiInstance.TmsV1InstrumentidentifiersPost("93B32398-AD51-4CC2-A682-EA3E93614EB1", requestObj);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(CreateInstrumentIdentifier)}):{e.Message}");
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(CreateInstrumentIdentifier)}");
                }
            }
        }
    }
}