using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class ProcessPayment
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;

        public static InlineResponse201 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var processingInformationObj = new V2paymentsProcessingInformation() { CommerceIndicator = "internet" };

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation { Code = "test_payment" };

            var pointOfSaleInformationObj = new V2paymentsPointOfSaleInformation
            {
                CardPresent = false,
                CatLevel = 6,
                TerminalCapability = 4
            };

            var orderInformationObj = new V2paymentsOrderInformation();

            var billToObj = new V2paymentsOrderInformationBillTo
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

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "102.21",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            var paymentInformationObj = new V2paymentsPaymentInformation();

            var cardObj = new V2paymentsPaymentInformationCard
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
                var apiInstance = new PaymentApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };
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
