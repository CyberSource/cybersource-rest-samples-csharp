using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ParallelAuth
    {
        public static async Task Run()
        {
            var task1 = Task.Run(() => AuthPayment());
            var task2 = Task.Run(() => AuthPayment());
            var task3 = Task.Run(() => AuthPayment());
            var task4 = Task.Run(() => AuthPayment());
            var task5 = Task.Run(() => AuthPayment());
            var task6 = Task.Run(() => AuthPayment());

            await task1;
            await task2;
            await task3;
            await task4;
            await task5;
            await task6;

            Console.WriteLine("COMPLETE");
        }

        public static PtsV2PaymentsPost201Response AuthPayment()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;

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

            string orderInformationAmountDetailsTotalAmount = new Random().Next(100, 1000).ToString();
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (ApiException err)
            {
                Console.WriteLine("Error Code: " + err.ErrorCode);
                Console.WriteLine("Error Message: " + err.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
