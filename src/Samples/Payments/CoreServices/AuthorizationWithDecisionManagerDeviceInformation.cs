using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class AuthorizationWithDecisionManagerDeviceInformation
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "54323007";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCardNumber = "4444444444444448";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2020";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard
           );

            string orderInformationAmountDetailsTotalAmount = "144.14";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "James";
            string orderInformationBillToLastName = "Smith";
            string orderInformationBillToAddress1 = "96, powers street";
            string orderInformationBillToLocality = "Clearwater milford";
            string orderInformationBillToAdministrativeArea = "NH";
            string orderInformationBillToPostalCode = "03055";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@visa.com";
            string orderInformationBillToPhoneNumber = "7606160717";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
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

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            string deviceInformationHostName = "host.com";
            string deviceInformationIpAddress = "64.124.61.215";
            string deviceInformationUserAgent = "Chrome";
            string deviceInformationHttpBrowserEmail = "xyz@gmail.com";
            Ptsv2paymentsDeviceInformation deviceInformation = new Ptsv2paymentsDeviceInformation(
                HostName: deviceInformationHostName,
                IpAddress: deviceInformationIpAddress,
                UserAgent: deviceInformationUserAgent,
                HttpBrowserEmail: deviceInformationHttpBrowserEmail
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                DeviceInformation: deviceInformation
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
