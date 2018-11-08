using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class ProcessPayment
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;

        public static PtsV2PaymentsPost201Response Run()
        {
            var processingInformationObj = new Ptsv2paymentsProcessingInformation() { CommerceIndicator = "internet" };

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation { Code = "test_payment" };

            var pointOfSaleInformationObj = new Ptsv2paymentsPointOfSaleInformation
            {
                CardPresent = false,
                CatLevel = 6,
                TerminalCapability = 4
            };

            var orderInformationObj = new Ptsv2paymentsOrderInformation();

            var billToObj = new Ptsv2paymentsOrderInformationBillTo
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

            var amountDetailsObj = new Ptsv2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "102.21",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            var paymentInformationObj = new Ptsv2paymentsPaymentInformation();

            var cardObj = new Ptsv2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                SecurityCode = "123",
                ExpirationMonth = "12"
            };

            paymentInformationObj.Card = cardObj;

            var requestObj = new CreatePaymentRequest
            {
                ProcessingInformation = processingInformationObj,
                PaymentInformation = paymentInformationObj,
                ClientReferenceInformation = clientReferenceInformationObj,
                PointOfSaleInformation = pointOfSaleInformationObj,
                OrderInformation = orderInformationObj
            };

            if (CaptureTrueForProcessPayment)
            {
                requestObj.ProcessingInformation.Capture = true;
            }

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new PaymentsApi(clientConfig);

                var result = apiInstance.CreatePayment(requestObj);
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
