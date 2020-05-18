using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class RestaurantCaptureWithGratuity
    {
        public static PtsV2PaymentsCapturesPost201Response Run()
        {
            var processPaymentId = RestaurantAuthorization.Run().Id;
            string clientReferenceInformationCode = "1234567890";
            string clientReferenceInformationPartnerThirdPartyCertificationNumber = "123456789012";
            Ptsv2paymentsClientReferenceInformationPartner clientReferenceInformationPartner = new Ptsv2paymentsClientReferenceInformationPartner(
                ThirdPartyCertificationNumber: clientReferenceInformationPartnerThirdPartyCertificationNumber
           );

            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Partner: clientReferenceInformationPartner
           );

            string processingInformationIndustryDataType = "restaurant";
            Ptsv2paymentsidcapturesProcessingInformation processingInformation = new Ptsv2paymentsidcapturesProcessingInformation(
                IndustryDataType: processingInformationIndustryDataType
           );

            string orderInformationAmountDetailsTotalAmount = "100";
            string orderInformationAmountDetailsCurrency = "USD";
            string orderInformationAmountDetailsGratuityAmount = "11.50";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency,
                GratuityAmount: orderInformationAmountDetailsGratuityAmount
           );

            Ptsv2paymentsidcapturesOrderInformation orderInformation = new Ptsv2paymentsidcapturesOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            var requestObj = new CapturePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CaptureApi(clientConfig);

                var result = apiInstance.CapturePayment(requestObj, processPaymentId);
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
