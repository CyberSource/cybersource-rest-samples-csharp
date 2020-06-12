using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class SaleUsingSwipedTrackDataForAcquirer
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "123456";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = true;
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

            string pointOfSaleInformationEntryMode = "swiped";
            int pointOfSaleInformationTerminalCapability = 2;
            string pointOfSaleInformationTrackData = "%B38000000000006^TEST/CYBS         ^2012121019761100      00868000000?;38000000000006=20121210197611868000?";
            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability,
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
