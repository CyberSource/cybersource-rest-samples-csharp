using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace CybsPayments.Payments.Authorize_Payment.AVS_Relax
{
    public class AvsRelaxNonRetail
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreatePaymentRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "TC1102345"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var deviceInformationObj = new V2paymentsDeviceInformation
            {
                HostName = "cybersource.com",
                IpAddress = "66.185.179.2"
            };

            requestObj.DeviceInformation = deviceInformationObj;

            var v2PaymentsProcessingInformationObj = new V2paymentsProcessingInformation();

            var authorizationOptionsObj = new V2paymentsProcessingInformationAuthorizationOptions
            {
                IgnoreAvsResult = true,
                IgnoreCvResult = false
            };

            v2PaymentsProcessingInformationObj.AuthorizationOptions = authorizationOptionsObj;

            requestObj.ProcessingInformation = v2PaymentsProcessingInformationObj;

            var buyerInformationObj = new V2paymentsBuyerInformation();
            var list = new List<V2paymentsBuyerInformationPersonalIdentification>();
            var personalIdentificationObj = new V2paymentsBuyerInformationPersonalIdentification
            {
                Id = "123* 4sÃ†"
            };

            list.Add(personalIdentificationObj);

            buyerInformationObj.PersonalIdentification = list;

            requestObj.BuyerInformation = buyerInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsOrderInformationBillTo
            {
                Country = "US",
                LastName = "VDP",
                Address2 = "test",
                Address1 = "201 S. Division St.",
                PostalCode = "48104-2201",
                Locality = "Ann Arbor",
                AdministrativeArea = "MI",
                FirstName = "RTS",
                PhoneNumber = "999999999",
                District = "MI",
                BuildingNumber = "123",
                Company = "Visa",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var amountDetailsObj = new V2paymentsOrderInformationAmountDetails
            {
                TotalAmount = "2401",
                Currency = "usd"
            };

            v2PaymentsOrderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2paymentsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "372425119311008",
                SecurityCode = "1111",
                ExpirationMonth = "12",
                Type = "003",
                SecurityCodeIndicator = "1"
            };

            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            var merchantConfig = new MerchantConfig(configDictionary)
            {
                RequestType = "POST",
                RequestTarget = "/pts/v2/payments",
                RequestJsonData = JsonConvert.SerializeObject(requestObj)
            };

            try
            {
                var configurationSwagger = new ApiClient().CallAuthenticationHeader(merchantConfig);
                var apiInstance = new PaymentApi(configurationSwagger);
                var result = apiInstance.CreatePayment(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
