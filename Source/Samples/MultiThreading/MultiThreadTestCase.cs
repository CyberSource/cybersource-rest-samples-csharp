using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Cybersource_rest_samples_dotnet.Samples.MultiThreading
{
    internal class MultiThreadTestCase
    {

        public void Run()
        {
            var tasks = new List<Task>();

            for (int i = 0; i < 50; i++)
            {
                int index = i; // capture loop variable
                // Wait for 2 seconds before starting the next task
                //System.Threading.Thread.Sleep(2000);
                //tasks.Add(Task.Run(() => SimpleAuthorizationInternet(index)));
                tasks.Add(Task.Run(() => CreateInstrumentIdentifier()));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private void SimpleAuthorizationInternet(int callNumber)
        {
            // Simulate authorization logic
            Console.WriteLine($"Authorization call {callNumber} started on thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            //var result = Run();
            // Place actual authorization logic here
        }

        public PtsV2PaymentsPost201Response SimpleAuthorizationInternet()
        {
            CreatePaymentRequest requestObj = GeneratePaymentRequest();

            try
            {
                var configDictionary = GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
                //WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.Message);
                Console.WriteLine("Exception on calling the API : " + e.Message);
                //WriteLogAudit(e.ErrorCode);
                return null;
            }
        }

        public void CreateInstrumentIdentifier()
        {
            try
            {
                //var obj = new ApiClient();
                //Dictionary<string, string> config = ;

                var config = new CyberSource.Client.Configuration(merchConfigDictObj: GetConfiguration());
                //obj.Configuration = config;
                var apiInstance = new InstrumentIdentifierApi(config);

                // Generate a random 4-digit number and convert it to string
                var random = new Random();
                string fourDigitString = random.Next(1000, 10000).ToString();
                var objRequest = new PostInstrumentIdentifierRequest
                {
                    Card = new TmsEmbeddedInstrumentIdentifierCard(Number: "41111111111" + fourDigitString)
                };

                PostInstrumentIdentifierRequest result = apiInstance.PostInstrumentIdentifier(objRequest);
                string ResultCardNumber = result.Card.Number;
                //Console.WriteLine(ResultCardNumber);

                // Get the last 4 digits of ResultCardNumber
                if (!string.IsNullOrEmpty(ResultCardNumber) && ResultCardNumber.Length >= 4)
                {
                    string last4 = ResultCardNumber.Substring(ResultCardNumber.Length - 4);
                    //Console.WriteLine("Last 4 digits: " + last4);

                    // Verify if last4 and fourDigitString are the same
                    if (last4 == fourDigitString)
                    {
                        Console.WriteLine("success");
                    }
                    else
                    {
                        Console.WriteLine("failure");
                    }
                }
                else
                {
                    Console.WriteLine("failure- cardNo in response not correct");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Message: " + e.Message);
            }
        }


        



        private Dictionary<string, string> GetConfiguration()
        {
            // Read configuration.json from the Resource folder
            //var resourcePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resource", "configuration.json");
            //provide confiuration.json path
            var resourcePath = "C:\\work-repo\\cybersource-sdk\\cybersource-rest-samples-csharp\\Source\\Resource\\configuration.json";
            if (!System.IO.File.Exists(resourcePath))
            {
                throw new System.IO.FileNotFoundException($"Configuration file not found at {resourcePath}");
            }

            var json = System.IO.File.ReadAllText(resourcePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        private static CreatePaymentRequest GeneratePaymentRequest()
        {
            // Generate a random number and convert it to string
            var random = new Random();
            string randomNumberString = random.Next().ToString();

            string clientReferenceInformationCode = "TC50171_3"+ randomNumberString;
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            //if (CaptureTrueForProcessPayment)
            //{
            //    processingInformationCapture = true;
            //}

            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2031";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToLocality = "san francisco";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94105";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "4158880000";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );
            return requestObj;
        }
    }

}