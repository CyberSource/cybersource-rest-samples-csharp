using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class PinDebitPurchaseUsingEMVTechnologyWithContactlessReadWithVisaPlatformConnect
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "2.2 Purchase";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            string processingInformationCommerceIndicator = "retail";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
           );

            string orderInformationAmountDetailsTotalAmount = "202.00";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            string pointOfSaleInformationEntryMode = "contactless";
            int pointOfSaleInformationTerminalCapability = 4;
            string pointOfSaleInformationEmvTags = "9F3303204000950500000000009F3704518823719F100706011103A000009F26081E1756ED0E2134E29F36020015820200009C01009F1A0208409A030006219F02060000000020005F2A0208409F0306000000000000";
            string pointOfSaleInformationEmvCardSequenceNumber = "1";
            bool pointOfSaleInformationEmvFallback = false;
            Ptsv2paymentsPointOfSaleInformationEmv pointOfSaleInformationEmv = new Ptsv2paymentsPointOfSaleInformationEmv(
                Tags: pointOfSaleInformationEmvTags,
                CardSequenceNumber: pointOfSaleInformationEmvCardSequenceNumber,
                Fallback: pointOfSaleInformationEmvFallback
           );

            string pointOfSaleInformationTrackData = "%B4111111111111111^JONES/JONES ^3112101976110000868000000?;4111111111111111=16121019761186800000?";
            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability,
                Emv: pointOfSaleInformationEmv,
                TrackData: pointOfSaleInformationTrackData
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                PointOfSaleInformation: pointOfSaleInformation
           );

            try
            {
                var configDictionary = new Configuration().GetAlternativeConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2PaymentsPost201Response result = apiInstance.CreatePayment(requestObj);
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
