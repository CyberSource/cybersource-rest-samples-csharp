using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class ProcessPaymentWithServiceFee
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;

        public static PtsV2PaymentsPost201Response Run()
        {
            var processingInformationObj = new Ptsv2paymentsProcessingInformation() { CommerceIndicator = "internet" };

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation { Code = "test_payment" };

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

            var amountDetailsObj = new Ptsv2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "2325.00",
                Currency = "USD",
                ServiceFeeAmount = "30.00"
            };

            var orderInformationObj = new Ptsv2paymentsOrderInformation();
            orderInformationObj.BillTo = billToObj;
            orderInformationObj.AmountDetails = amountDetailsObj;

            var cardObj = new Ptsv2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                ExpirationMonth = "12"
            };

            var paymentInformationObj = new Ptsv2paymentsPaymentInformation();
            paymentInformationObj.Card = cardObj;

            var serviceFeeDescriptorObj = new Ptsv2paymentsMerchantInformationServiceFeeDescriptor
            {
                Name = "CyberSource Service Fee",
                Contact = "800-999-9999",
                State = "CA",

            };

            var merchantInformationObj = new Ptsv2paymentsMerchantInformation();
            merchantInformationObj.ServiceFeeDescriptor = serviceFeeDescriptorObj;
			
            var requestObj = new CreatePaymentRequest
            {
                ProcessingInformation = processingInformationObj,
                PaymentInformation = paymentInformationObj,
                ClientReferenceInformation = clientReferenceInformationObj,
                OrderInformation = orderInformationObj,
                MerchantInformation = merchantInformationObj
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
