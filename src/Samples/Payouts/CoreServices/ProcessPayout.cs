using System;
using System.Collections.Generic;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payouts.CoreServices
{
    public class ProcessPayout
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new OctCreatePaymentRequest();

            var clientReferenceInformationObj = new InlineResponse201ClientReferenceInformation
            {
                Code = "33557799"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var senderInformationObj = new V2payoutsSenderInformation
            {
                ReferenceNumber = "1234567890",
                Address1 = "900 Metro Center Blvd.900",
                CountryCode = "US",
                Locality = "San Francisco",
                Name = "Thomas Jefferson",
                AdministrativeArea = "CA"
            };

            var accountObj = new V2payoutsSenderInformationAccount
            {
                Number = "1234567890123456789012345678901234",
                FundsSource = "01"
            };

            senderInformationObj.Account = accountObj;

            requestObj.SenderInformation = senderInformationObj;

            var processingInformationObj = new V2payoutsProcessingInformation
            {
                CommerceIndicator = "internet",
                BusinessApplicationId = "FD",
                NetworkRoutingOrder = "ECG"
            };

            requestObj.ProcessingInformation = processingInformationObj;

            var orderInformationObj = new V2payoutsOrderInformation();

            var amountDetailsObj = new V2payoutsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            var merchantInformationObj = new V2payoutsMerchantInformation
            {
                CategoryCode = 123
            };

            var merchantDescriptorObj = new V2payoutsMerchantInformationMerchantDescriptor
            {
                Country = "US",
                PostalCode = "94440",
                Locality = "FC",
                Name = "Thomas",
                AdministrativeArea = "CA"
            };

            merchantInformationObj.MerchantDescriptor = merchantDescriptorObj;

            requestObj.MerchantInformation = merchantInformationObj;

            var paymentInformationObj = new V2payoutsPaymentInformation();

            var cardObj = new V2payoutsPaymentInformationCard
            {
                ExpirationYear = "2025",
                Number = "4111111111111111",
                ExpirationMonth = "12",
                Type = "001",
                SourceAccountType = "CH"
            };

            paymentInformationObj.Card = cardObj;

            requestObj.PaymentInformation = paymentInformationObj;

            var recipientInformationObj = new V2payoutsRecipientInformation
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "Paseo Padre Boulevard",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                PostalCode = "94400",
                PhoneNumber = "6504320556",
                DateOfBirth = "19801009",
                Country = "US"
            };

            requestObj.RecipientInformation = recipientInformationObj;

            try
            {
                var apiInstance = new DefaultApi();
                var result = apiInstance.OctCreatePaymentWithHttpInfo(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
