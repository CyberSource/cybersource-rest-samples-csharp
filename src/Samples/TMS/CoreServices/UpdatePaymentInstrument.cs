using System;
using CyberSource.Api;
using CyberSource.Model;
using Newtonsoft.Json;
using NLog;

namespace Cybersource_rest_samples_dotnet.Samples.TMS.CoreServices
{
    public class UpdatePaymentInstrument
    {
        public static void Run()
        {
            Console.WriteLine($"\n[BEGIN] EXECUTION OF SAMPLE CODE: {nameof(UpdatePaymentInstrument)}");

            Logger logger = LogManager.GetCurrentClassLogger();
            CyberSource.Client.Configuration clientConfig = null;
            TmsV1PaymentinstrumentsPost201Response result = null;

            var profileId = "93B32398-AD51-4CC2-A682-EA3E93614EB1";
            var tokenId = CreatePaymentInstrument.Run().Id;

            var requestObj = new Body3();

            var cardObj = new Tmsv1paymentinstrumentsCard
            {
                ExpirationMonth = "09",
                ExpirationYear = "2022",
                Type = Tmsv1paymentinstrumentsCard.TypeEnum.Visa
            };

            requestObj.Card = cardObj;

            var billToObj = new Tmsv1paymentinstrumentsBillTo
            {
                FirstName = "John",
                LastName = "Smith",
                Company = "CyberSource",
                Address1 = "12 Main Street",
                Address2 = "20 My Street",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                PostalCode = "90200",
                Country = "US",
                Email = "john.smith@example.com",
                PhoneNumber = "555123456"
            };

            requestObj.BillTo = billToObj;

            var instrumentIdentifierObj = new Tmsv1paymentinstrumentsInstrumentIdentifier();

            var cardObj2 = new Tmsv1instrumentidentifiersCard
            {
                Number = "4111111111111111"
            };

            instrumentIdentifierObj.Card = cardObj2;

            requestObj.InstrumentIdentifier = instrumentIdentifierObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentInstrumentsApi(clientConfig);

                result = apiInstance.TmsV1PaymentinstrumentsTokenIdPatch(profileId, tokenId, requestObj);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException on calling the Sample Code({nameof(UpdatePaymentInstrument)}):{e.Message}");
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

                    Console.WriteLine($"\n[END] EXECUTION OF SAMPLE CODE: {nameof(UpdatePaymentInstrument)}");
                }
            }
        }
    }
}