using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payouts
{
    public class Payouts
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new OctCreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new InlineResponse201ClientReferenceInformation
            {
                Code = "33557799"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var senderInformationObj = new V2payoutsSenderInformation
            {
                ReferenceNumber = "1234567890",
                Address1 = "900 Metro Center Blvd.900",
                CountryCode = "US",
                Locality = "San Francisco",
                Name = "Company Name",
                AdministrativeArea = "CA"
            };

            var accountObj = new V2payoutsSenderInformationAccount
            {
                FundsSource = "05"
            };

            senderInformationObj.Account = accountObj;

            requestObj.SenderInformation = senderInformationObj;

            var v2PaymentsProcessingInformationObj = new V2payoutsProcessingInformation
            {
                CommerceIndicator = "internet",
                BusinessApplicationId = "FD"
            };

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var v2PaymentsOrderInformationObj = new V2payoutsOrderInformation();

            var v2PaymentsOrderInformationAmountDetailsObj = new V2payoutsOrderInformationAmountDetails
            {
                TotalAmount = "100.00",
                Currency = "USD"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var merchantInformationObj = new V2payoutsMerchantInformation();

            var merchantDescriptorObj = new V2payoutsMerchantInformationMerchantDescriptor
            {
                Country = "US",
                PostalCode = "94440",
                Locality = "FC",
                Name = "Sending Company Name",
                AdministrativeArea = "CA"
            };

            merchantInformationObj.MerchantDescriptor = merchantDescriptorObj;

            requestObj.MerchantInformation = merchantInformationObj;

            var v2PaymentsPaymentInformationObj = new V2payoutsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2payoutsPaymentInformationCard
            {
                ExpirationYear = "2025",
                Number = "4111111111111111",
                ExpirationMonth = "12",
                Type = "001"
            };

            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            var recipientInformationObj = new V2payoutsRecipientInformation
            {
                FirstName = "John",
                LastName = "Doe",
                Address1 = "Paseo Padre Boulevard",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                PostalCode = "94400",
                PhoneNumber = "6504320556",
                Country = "US"
            };

            requestObj.RecipientInformation = recipientInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payouts",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new DefaultApi(configurationSwagger);
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
