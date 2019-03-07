using System;
using CyberSource.Api;
using CyberSource.Model;


namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class ProcessEcheckCreditWIthServiceFee
    {
        public static void Run()
        {
            var echeckPaymentWithServiceFeecapturePaymentId = ProcessEcheckPaymentWithServiceFee.Run().Id;

            // This is a section to set client reference information
            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation("test_refund_capture");
            // This is the block to set Amount detail to be credited
            var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails("102.21", "USD");

            // This is the block to set Bill to object information
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

            var orderInformationObj = new Ptsv2paymentsidrefundsOrderInformation(amountDetailsObj, billToObj);

            // This is the block to set payment information by providing bank account details
            var paymentInformationObj = new Ptsv2paymentsidrefundsPaymentInformation();
            var bankAccountObj = new Ptsv2paymentsPaymentInformationBankAccount
            {
                Number = "4100",
                Type = "C",
                CheckNumber = "123456"
            };

            var bankObj = new Ptsv2paymentsPaymentInformationBank
            {
                Account = bankAccountObj
            };
            bankObj.RoutingNumber = "071923284";
            paymentInformationObj.Bank = bankObj;

            // This is the block to set request body to the request object
            var requestBody = new RefundCaptureRequest(clientReferenceInformationObj, null, paymentInformationObj, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new RefundApi(clientConfig);

                var result = apiInstance.RefundCapture(requestBody, echeckPaymentWithServiceFeecapturePaymentId);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}