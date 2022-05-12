using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class IncrementalAuthorization
    {
        public static PtsV2IncrementalAuthorizationPatch201Response Run()
        {
            string id = AuthorizationForIncrementalAuthorizationFlow.Run().Id;
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsidClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

			string processingInformationAuthorizationOptionsInitiatorStoredCredentialUsed = "true";
            Ptsv2paymentsidProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Ptsv2paymentsidProcessingInformationAuthorizationOptionsInitiator(
                StoredCredentialUsed: processingInformationAuthorizationOptionsInitiatorStoredCredentialUsed
           );

            Ptsv2paymentsidProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Ptsv2paymentsidProcessingInformationAuthorizationOptions(
                Initiator: processingInformationAuthorizationOptionsInitiator
           );

            Ptsv2paymentsidProcessingInformation processingInformation = new Ptsv2paymentsidProcessingInformation(
                AuthorizationOptions: processingInformationAuthorizationOptions
           );

            string orderInformationAmountDetailsAdditionalAmount = "22.49";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsidOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidOrderInformationAmountDetails(
                AdditionalAmount: orderInformationAmountDetailsAdditionalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsidOrderInformation orderInformation = new Ptsv2paymentsidOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            string merchantInformationTransactionLocalDateTime = "20191002080000";
            Ptsv2paymentsidMerchantInformation merchantInformation = new Ptsv2paymentsidMerchantInformation(
                TransactionLocalDateTime: merchantInformationTransactionLocalDateTime
           );

            string travelInformationDuration = "4";
            Ptsv2paymentsidTravelInformation travelInformation = new Ptsv2paymentsidTravelInformation(
                Duration: travelInformationDuration
           );

            var requestObj = new IncrementAuthRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                OrderInformation: orderInformation,
                MerchantInformation: merchantInformation,
                TravelInformation: travelInformation
           );

            try
            {
                var configDictionary = new Configuration().GetAlternativeConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentsApi(clientConfig);
                PtsV2IncrementalAuthorizationPatch201Response result = apiInstance.IncrementAuth(id, requestObj);
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
