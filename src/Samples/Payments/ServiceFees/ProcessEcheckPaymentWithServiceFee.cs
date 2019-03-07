using System;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class ProcessEcheckPaymentWithServiceFee
    {
        public static bool CaptureTrueForProcessPayment { get; set; } = false;

        public static PtsV2PaymentsPost201Response Run()
        {
            var processingInformationObj = new Ptsv2paymentsProcessingInformation() { CommerceIndicator = "internet" };

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation { Code = "test_payment" };

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
                TotalAmount = "2325.00",
                ServiceFeeAmount = "30.0",
                Currency = "USD",
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            var paymentInformationObj = new Ptsv2paymentsPaymentInformation();
            var bankAccountObj=new Ptsv2paymentsPaymentInformationBankAccount
            {
                Number = "4100",
                Type = "C",
            };

            var bankObj = new Ptsv2paymentsPaymentInformationBank
            {
                 Account = bankAccountObj,
                 RoutingNumber = "071923284",
            };
            paymentInformationObj.Bank = bankObj;

            var requestObj = new CreatePaymentRequest
            {
                ProcessingInformation = processingInformationObj,
                PaymentInformation = paymentInformationObj,
                ClientReferenceInformation = clientReferenceInformationObj,
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
