using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class ElectronicCheckStandAloneCredits
    {
        public static PtsV2CreditsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC46125-1";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationBankAccountType = "C";
            string paymentInformationBankAccountNumber = "4100";
            string paymentInformationBankAccountCheckNumber = "123456";
            Ptsv2paymentsidrefundsPaymentInformationBankAccount paymentInformationBankAccount = new Ptsv2paymentsidrefundsPaymentInformationBankAccount(
                Type: paymentInformationBankAccountType,
                Number: paymentInformationBankAccountNumber,
                CheckNumber: paymentInformationBankAccountCheckNumber
           );

            string paymentInformationBankRoutingNumber = "071923284";
            Ptsv2paymentsidrefundsPaymentInformationBank paymentInformationBank = new Ptsv2paymentsidrefundsPaymentInformationBank(
                Account: paymentInformationBankAccount,
                RoutingNumber: paymentInformationBankRoutingNumber
           );

            string paymentInformationPaymentTypeName = "CHECK";
            Ptsv2paymentsidrefundsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsidrefundsPaymentInformationPaymentType(
                Name: paymentInformationPaymentTypeName
           );

            Ptsv2paymentsidrefundsPaymentInformation paymentInformation = new Ptsv2paymentsidrefundsPaymentInformation(
                Bank: paymentInformationBank,
                PaymentType: paymentInformationPaymentType
           );

            string orderInformationAmountDetailsTotalAmount = "100";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsidcapturesOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsidcapturesOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToAddress1 = "1 Market St";
            string orderInformationBillToLocality = "san francisco";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "94105";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "4158880000";
            Ptsv2paymentsidcapturesOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsidcapturesOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsidrefundsOrderInformation orderInformation = new Ptsv2paymentsidrefundsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            var requestObj = new CreateCreditRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new CreditApi(clientConfig);
                PtsV2CreditsPost201Response result = apiInstance.CreateCredit(requestObj);
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
