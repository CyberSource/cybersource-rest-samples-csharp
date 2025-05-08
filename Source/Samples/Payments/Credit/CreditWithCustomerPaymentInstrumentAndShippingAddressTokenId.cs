using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class CreditWithCustomerPaymentInstrumentAndShippingAddressTokenId
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PtsV2CreditsPost201Response Run()
        {
            string clientReferenceInformationCode = "12345678";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCustomerId = "AB695DA801DD1BB6E05341588E0A3BDC";
            Ptsv2paymentsPaymentInformationCustomer paymentInformationCustomer = new Ptsv2paymentsPaymentInformationCustomer(
                Id: paymentInformationCustomerId
           );

            string paymentInformationPaymentInstrumentId = "AB6A54B982A6FCB6E05341588E0A3935";
            Ptsv2paymentsPaymentInformationPaymentInstrument paymentInformationPaymentInstrument = new Ptsv2paymentsPaymentInformationPaymentInstrument(
                Id: paymentInformationPaymentInstrumentId
           );

            string paymentInformationShippingAddressId = "AB6A54B97C00FCB6E05341588E0A3935";
            Ptsv2paymentsPaymentInformationShippingAddress paymentInformationShippingAddress = new Ptsv2paymentsPaymentInformationShippingAddress(
                Id: paymentInformationShippingAddressId
           );

            Ptsv2paymentsidrefundsPaymentInformation paymentInformation = new Ptsv2paymentsidrefundsPaymentInformation(
                Customer: paymentInformationCustomer,
                PaymentInstrument: paymentInformationPaymentInstrument,
                ShippingAddress: paymentInformationShippingAddress
           );

            string orderInformationAmountDetailsTotalAmount = "200";
            string orderInformationAmountDetailsCurrency = "usd";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsidrefundsOrderInformation orderInformation = new Ptsv2paymentsidrefundsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            var requestObj = new CreateCreditRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CreditApi(clientConfig);
                PtsV2CreditsPost201Response result = apiInstance.CreateCredit(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
