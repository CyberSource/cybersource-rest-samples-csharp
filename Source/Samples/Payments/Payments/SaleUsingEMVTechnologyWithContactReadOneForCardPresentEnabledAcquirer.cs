using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class SaleUsingEMVTechnologyWithContactReadOneForCardPresentEnabledAcquirer
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "123456";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            string processingInformationCommerceIndicator = "retail";
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator
           );

            string orderInformationAmountDetailsTotalAmount = "100.00";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            int pointOfSaleInformationCatLevel = 1;
            string pointOfSaleInformationEntryMode = "contact";
            int pointOfSaleInformationTerminalCapability = 1;
            string pointOfSaleInformationEmvCardSequenceNumber = "0";
            bool pointOfSaleInformationEmvFallback = false;
            Ptsv2paymentsPointOfSaleInformationEmv pointOfSaleInformationEmv = new Ptsv2paymentsPointOfSaleInformationEmv(
                CardSequenceNumber: pointOfSaleInformationEmvCardSequenceNumber,
                Fallback: pointOfSaleInformationEmvFallback
           );

            string pointOfSaleInformationTrackData = "%B4111111111111111^TEST/CYBS         ^2012121019761100      00868000000?;";
            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                CatLevel: pointOfSaleInformationCatLevel,
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability,
                Emv: pointOfSaleInformationEmv,
                TrackData: pointOfSaleInformationTrackData
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                OrderInformation: orderInformation,
                PointOfSaleInformation: pointOfSaleInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
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
