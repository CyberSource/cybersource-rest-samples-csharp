using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class ProcessCredit
    {
        public static void Run(IReadOnlyDictionary<string, string> configDictionary)
        {
            var requestObj = new CreateCreditRequest();

            var v2PaymentsClientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "test_credits"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsOrderInformationObj = new V2paymentsidrefundsOrderInformation();

            var v2PaymentsOrderInformationBillToObj = new V2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "4158880000",
                Address1 = "1 Market St",
                PostalCode = "94105",
                Locality = "san francisco",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "200",
                Currency = "usd"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new V2paymentsidrefundsPaymentInformation();

            var v2PaymentsPaymentInformationCardObj = new V2paymentsidrefundsPaymentInformationCard
            {
                ExpirationYear = "2031",
                Number = "4111111111111111",
                ExpirationMonth = "03",
                Type = "001"
            };

            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            try
            {
                var apiInstance = new CreditApi();
                var result = apiInstance.CreateCredit(requestObj);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
            }
        }
    }
}
