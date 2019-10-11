using System;
using System.Collections.Generic;
using System.Globalization;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class CapturePaymentServiceFee
    {
        public static PtsV2PaymentsCapturesPost201Response Run(string id)
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsTotalAmount = "2325.00";
            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsServiceFeeAmount = "30.0";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency,
                ServiceFeeAmount: orderInformationAmountDetailsServiceFeeAmount
           );

            Ptsv2paymentsidcapturesOrderInformation orderInformation = new Ptsv2paymentsidcapturesOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            string merchantInformationServiceFeeDescriptorName = "Vacations Service Fee";
            string merchantInformationServiceFeeDescriptorContact = "8009999999";
            string merchantInformationServiceFeeDescriptorState = "CA";
            Ptsv2paymentsMerchantInformationServiceFeeDescriptor merchantInformationServiceFeeDescriptor = new Ptsv2paymentsMerchantInformationServiceFeeDescriptor(
                Name: merchantInformationServiceFeeDescriptorName,
                Contact: merchantInformationServiceFeeDescriptorContact,
                State: merchantInformationServiceFeeDescriptorState
           );

            Ptsv2paymentsidcapturesMerchantInformation merchantInformation = new Ptsv2paymentsidcapturesMerchantInformation(
                ServiceFeeDescriptor: merchantInformationServiceFeeDescriptor
           );

            var requestObj = new CapturePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                MerchantInformation: merchantInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CaptureApi(clientConfig);
                PtsV2PaymentsCapturesPost201Response result = apiInstance.CapturePayment(requestObj, id);
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
