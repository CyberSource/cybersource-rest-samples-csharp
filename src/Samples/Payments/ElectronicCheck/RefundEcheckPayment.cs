using System;
using CyberSource.Api;
using CyberSource.Model;
using Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ElectronicCheck
{
    public class RefundEcheckPayment
    {
        public static PtsV2PaymentsRefundPost201Response Run()
        {
            var capturePaymentId = CapturePayment.Run().Id;

            var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation("test_refund_capture");
            
			var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails("102.21", "USD");

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
			
            var paymentInformationObj = new Ptsv2paymentsidrefundsPaymentInformation();			
            paymentInformationObj.Bank = bankObj;

            var requestBody = new RefundCaptureRequest(clientReferenceInformationObj, null, paymentInformationObj, orderInformationObj);

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new RefundApi(clientConfig);

                var result = apiInstance.RefundCapture(requestBody, capturePaymentId);

                Console.WriteLine(result.Id);
				
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