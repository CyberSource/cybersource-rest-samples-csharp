using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class SaleUsingEMVTechnologyWithContactlessReadForCardPresentEnabledAcquirer
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "123456";
            string clientReferenceInformationPartnerOriginalTransactionId = "510be4aef90711e6acbc7d88388d803d";
            Ptsv2paymentsClientReferenceInformationPartner clientReferenceInformationPartner = new Ptsv2paymentsClientReferenceInformationPartner(
                OriginalTransactionId: clientReferenceInformationPartnerOriginalTransactionId
           );

            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode,
                Partner: clientReferenceInformationPartner
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

            int pointOfSaleInformationCatLevel = 1;
            string pointOfSaleInformationEntryMode = "contactless";
            int pointOfSaleInformationTerminalCapability = 5;
            string pointOfSaleInformationEmvTags = "9F3303204000950500000000009F3704518823719F100706011103A000009F26081E1756ED0E2134E29F36020015820200009C01009F1A0208409A030006219F02060000000020005F2A0208409F0306000000000000";
            int pointOfSaleInformationEmvCardholderVerificationMethodUsed = 2;
            string pointOfSaleInformationEmvCardSequenceNumber = "1";
            bool pointOfSaleInformationEmvFallback = false;
            Ptsv2paymentsPointOfSaleInformationEmv pointOfSaleInformationEmv = new Ptsv2paymentsPointOfSaleInformationEmv(
                Tags: pointOfSaleInformationEmvTags,
                CardholderVerificationMethodUsed: pointOfSaleInformationEmvCardholderVerificationMethodUsed,
                CardSequenceNumber: pointOfSaleInformationEmvCardSequenceNumber,
                Fallback: pointOfSaleInformationEmvFallback
           );

            string pointOfSaleInformationTrackData = "%B4111111111111111^TEST/CYBS         ^2012121019761100      00868000000?;";

            List<string> pointOfSaleInformationCardholderVerificationMethod = new List<string>();
            pointOfSaleInformationCardholderVerificationMethod.Add("pin");
            pointOfSaleInformationCardholderVerificationMethod.Add("signature");

            List<string> pointOfSaleInformationTerminalInputCapability = new List<string>();
            pointOfSaleInformationTerminalInputCapability.Add("contact");
            pointOfSaleInformationTerminalInputCapability.Add("contactless");
            pointOfSaleInformationTerminalInputCapability.Add("keyed");
            pointOfSaleInformationTerminalInputCapability.Add("swiped");
            string pointOfSaleInformationTerminalCardCaptureCapability = "1";
            string pointOfSaleInformationDeviceId = "123lkjdIOBK34981slviLI39bj";
            string pointOfSaleInformationEncryptedKeySerialNumber = "01043191";
            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                CatLevel: pointOfSaleInformationCatLevel,
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability,
                Emv: pointOfSaleInformationEmv,
                TrackData: pointOfSaleInformationTrackData,
                CardholderVerificationMethod: pointOfSaleInformationCardholderVerificationMethod,
                TerminalInputCapability: pointOfSaleInformationTerminalInputCapability,
                TerminalCardCaptureCapability: pointOfSaleInformationTerminalCardCaptureCapability,
                DeviceId: pointOfSaleInformationDeviceId,
                EncryptedKeySerialNumber: pointOfSaleInformationEncryptedKeySerialNumber
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
