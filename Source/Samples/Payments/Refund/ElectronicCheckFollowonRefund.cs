using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ElectronicCheckFollowonRefund
    {
        public static PtsV2PaymentsRefundPost201Response Run()
        {
            var id = ElectronicCheckDebits.Run().Id;

            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsidrefundsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidrefundsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            Ptsv2paymentsidrefundsProcessingInformation processingInformation = new Ptsv2paymentsidrefundsProcessingInformation(
           );

            string paymentInformationPaymentTypeName = "CHECK";
            Ptsv2paymentsidrefundsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsidrefundsPaymentInformationPaymentType(
                Name: paymentInformationPaymentTypeName
           );

            Ptsv2paymentsidrefundsPaymentInformation paymentInformation = new Ptsv2paymentsidrefundsPaymentInformation(
                PaymentType: paymentInformationPaymentType
           );

            string orderInformationAmountDetailsTotalAmount = "100";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsidrefundsOrderInformation orderInformation = new Ptsv2paymentsidrefundsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            var requestObj = new RefundPaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new RefundApi(clientConfig);
                PtsV2PaymentsRefundPost201Response result = apiInstance.RefundPayment(requestObj, id);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                return null;
            }
        }
    }
}
