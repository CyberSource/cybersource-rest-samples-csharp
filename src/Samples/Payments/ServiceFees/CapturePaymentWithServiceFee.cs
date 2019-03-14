using System;
using CyberSource.Api;
using CyberSource.Model;
using Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
        public class CapturePaymentWithServiceFee
        {
            public static PtsV2PaymentsRefundPost201Response Run()
            {
                ProcessPayment.CaptureTrueForProcessPayment = true;
				
                var processPaymentId = ProcessPayment.Run().Id;
				
                var clientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation("test_refund_payment");

				var amountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails
                {
                    TotalAmount = "2325.00",
                    Currency = "USD",
                    ServiceFeeAmount = "30.00"
                };
				
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

                var requestBody = new RefundPaymentRequest
                {
                    PaymentInformation = paymentInformationObj,
                    ClientReferenceInformation = clientReferenceInformationObj,
                    OrderInformation = orderInformationObj
                };

                try
                {
                    var configDictionary = new Configuration().GetConfiguration();
                    var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                    var apiInstance = new RefundApi(clientConfig);
					
                    var result = apiInstance.RefundPayment(requestBody, processPaymentId);
					
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