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
            string clientReferenceInformationPartnerOriginalTransactionId = "12345";
            string clientReferenceInformationPartnerDeveloperId = "12345";
            string clientReferenceInformationPartnerSolutionId = "12345";
            Ptsv2paymentsidClientReferenceInformationPartner clientReferenceInformationPartner = new Ptsv2paymentsidClientReferenceInformationPartner(
                OriginalTransactionId: clientReferenceInformationPartnerOriginalTransactionId,
                DeveloperId: clientReferenceInformationPartnerDeveloperId,
                SolutionId: clientReferenceInformationPartnerSolutionId
           );

            Ptsv2paymentsidClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidClientReferenceInformation(
                Partner: clientReferenceInformationPartner
           );

            bool processingInformationAuthorizationOptionsInitiatorStoredCredentialUsed = true;
            Ptsv2paymentsidProcessingInformationAuthorizationOptionsInitiator processingInformationAuthorizationOptionsInitiator = new Ptsv2paymentsidProcessingInformationAuthorizationOptionsInitiator(
                StoredCredentialUsed: processingInformationAuthorizationOptionsInitiatorStoredCredentialUsed
           );

            Ptsv2paymentsidProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Ptsv2paymentsidProcessingInformationAuthorizationOptions(
                Initiator: processingInformationAuthorizationOptionsInitiator
           );

            Ptsv2paymentsidProcessingInformation processingInformation = new Ptsv2paymentsidProcessingInformation(
                AuthorizationOptions: processingInformationAuthorizationOptions
           );

            string orderInformationAmountDetailsAdditionalAmount = "100";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsidOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidOrderInformationAmountDetails(
                AdditionalAmount: orderInformationAmountDetailsAdditionalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsidOrderInformation orderInformation = new Ptsv2paymentsidOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            Ptsv2paymentsidMerchantInformation merchantInformation = new Ptsv2paymentsidMerchantInformation(
           );

            string travelInformationDuration = "3";
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
