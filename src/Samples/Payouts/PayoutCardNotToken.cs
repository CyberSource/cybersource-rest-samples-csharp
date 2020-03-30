using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payouts
{
    public class PayoutCardNotToken
    {
        public static PtsV2PayoutsPost201Response Run()
        {
            string clientReferenceInformationCode = "33557799";
            PtsV2IncrementalAuthorizationPatch201ResponseClientReferenceInformation clientReferenceInformation = new PtsV2IncrementalAuthorizationPatch201ResponseClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsTotalAmount = "100.00";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2payoutsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2payoutsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2payoutsOrderInformation orderInformation = new Ptsv2payoutsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            string merchantInformationMerchantDescriptorName = "Sending Company Name";
            string merchantInformationMerchantDescriptorLocality = "FC";
            string merchantInformationMerchantDescriptorCountry = "US";
            string merchantInformationMerchantDescriptorAdministrativeArea = "CA";
            string merchantInformationMerchantDescriptorPostalCode = "94440";
            Ptsv2payoutsMerchantInformationMerchantDescriptor merchantInformationMerchantDescriptor = new Ptsv2payoutsMerchantInformationMerchantDescriptor(
                Name: merchantInformationMerchantDescriptorName,
                Locality: merchantInformationMerchantDescriptorLocality,
                Country: merchantInformationMerchantDescriptorCountry,
                AdministrativeArea: merchantInformationMerchantDescriptorAdministrativeArea,
                PostalCode: merchantInformationMerchantDescriptorPostalCode
           );

            Ptsv2payoutsMerchantInformation merchantInformation = new Ptsv2payoutsMerchantInformation(
                MerchantDescriptor: merchantInformationMerchantDescriptor
           );

            string recipientInformationFirstName = "John";
            string recipientInformationLastName = "Doe";
            string recipientInformationAddress1 = "Paseo Padre Boulevard";
            string recipientInformationLocality = "Foster City";
            string recipientInformationAdministrativeArea = "CA";
            string recipientInformationCountry = "US";
            string recipientInformationPostalCode = "94400";
            string recipientInformationPhoneNumber = "6504320556";
            Ptsv2payoutsRecipientInformation recipientInformation = new Ptsv2payoutsRecipientInformation(
                FirstName: recipientInformationFirstName,
                LastName: recipientInformationLastName,
                Address1: recipientInformationAddress1,
                Locality: recipientInformationLocality,
                AdministrativeArea: recipientInformationAdministrativeArea,
                Country: recipientInformationCountry,
                PostalCode: recipientInformationPostalCode,
                PhoneNumber: recipientInformationPhoneNumber
           );

            string senderInformationReferenceNumber = "1234567890";
            string senderInformationAccountFundsSource = "05";
            Ptsv2payoutsSenderInformationAccount senderInformationAccount = new Ptsv2payoutsSenderInformationAccount(
                FundsSource: senderInformationAccountFundsSource
           );

            string senderInformationName = "Company Name";
            string senderInformationAddress1 = "900 Metro Center Blvd.900";
            string senderInformationLocality = "Foster City";
            string senderInformationAdministrativeArea = "CA";
            string senderInformationCountryCode = "US";
            Ptsv2payoutsSenderInformation senderInformation = new Ptsv2payoutsSenderInformation(
                ReferenceNumber: senderInformationReferenceNumber,
                Account: senderInformationAccount,
                Name: senderInformationName,
                Address1: senderInformationAddress1,
                Locality: senderInformationLocality,
                AdministrativeArea: senderInformationAdministrativeArea,
                CountryCode: senderInformationCountryCode
           );

            string processingInformationBusinessApplicationId = "FD";
            string processingInformationNetworkRoutingOrder = "V8";
            string processingInformationCommerceIndicator = "internet";
            Ptsv2payoutsProcessingInformation processingInformation = new Ptsv2payoutsProcessingInformation(
                BusinessApplicationId: processingInformationBusinessApplicationId,
                NetworkRoutingOrder: processingInformationNetworkRoutingOrder,
                CommerceIndicator: processingInformationCommerceIndicator
           );

            string paymentInformationCardType = "001";
            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2025";
            Ptsv2payoutsPaymentInformationCard paymentInformationCard = new Ptsv2payoutsPaymentInformationCard(
                Type: paymentInformationCardType,
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            Ptsv2payoutsPaymentInformation paymentInformation = new Ptsv2payoutsPaymentInformation(
                Card: paymentInformationCard
           );

            var requestObj = new OctCreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                OrderInformation: orderInformation,
                MerchantInformation: merchantInformation,
                RecipientInformation: recipientInformation,
                SenderInformation: senderInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PayoutsApi(clientConfig);
                PtsV2PayoutsPost201Response result = apiInstance.OctCreatePayment(requestObj);
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
