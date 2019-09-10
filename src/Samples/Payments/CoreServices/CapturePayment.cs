using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class CapturePayment
    {
        public static PtsV2PaymentsCapturesPost201Response Run()
        {
            var processPaymentId = ProcessPayment.Run().Id;

            var requestObj = new CapturePaymentRequest();

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation
            {
                Code = "test_capture"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

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
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new CaptureApi(clientConfig);

                var result = apiInstance.CapturePayment(requestObj, processPaymentId);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
