using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class AuthorizationWithCustomerTokenDefaultPaymentInstrumentAndShippingAddressCreation
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );


            List <string> processingInformationActionList = new List <string>();
            processingInformationActionList.Add("TOKEN_CREATE");

            List <string> processingInformationActionTokenTypes = new List <string>();
            processingInformationActionTokenTypes.Add("paymentInstrument");
            processingInformationActionTokenTypes.Add("shippingAddress");
            bool processingInformationCapture = false;
            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                ActionList: processingInformationActionList,
                ActionTokenTypes: processingInformationActionTokenTypes,
                Capture: processingInformationCapture
           );

            string paymentInformationCardNumber = "4111111111111111";
            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2031";
            string paymentInformationCardSecurityCode = "123";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                Number: paymentInformationCardNumber,
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear,
                SecurityCode: paymentInformationCardSecurityCode
           );

            string paymentInformationCustomerId = "AB695DA801DD1BB6E05341588E0A3BDC";
            Ptsv2paymentsPaymentInformationCustomer paymentInformationCustomer = new Ptsv2paymentsPaymentInformationCustomer(
                Id: paymentInformationCustomerId
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard,
                Customer: paymentInformationCustomer
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
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

            string orderInformationShipToFirstName = "John";
            string orderInformationShipToLastName = "Doe";
            string orderInformationShipToAddress1 = "1 Market St";
            string orderInformationShipToLocality = "san francisco";
            string orderInformationShipToAdministrativeArea = "CA";
            string orderInformationShipToPostalCode = "94105";
            string orderInformationShipToCountry = "US";
            Ptsv2paymentsOrderInformationShipTo orderInformationShipTo = new Ptsv2paymentsOrderInformationShipTo(
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName,
                Address1: orderInformationShipToAddress1,
                Locality: orderInformationShipToLocality,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                PostalCode: orderInformationShipToPostalCode,
                Country: orderInformationShipToCountry
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo
           );

            bool tokenInformationPaymentInstrument_default = true;
            Ptsv2paymentsTokenInformationPaymentInstrument tokenInformationPaymentInstrument = new Ptsv2paymentsTokenInformationPaymentInstrument(
                _Default: tokenInformationPaymentInstrument_default
           );

            bool tokenInformationShippingAddress_default = true;
            Ptsv2paymentsTokenInformationShippingAddress tokenInformationShippingAddress = new Ptsv2paymentsTokenInformationShippingAddress(
                _Default: tokenInformationShippingAddress_default
           );

            Ptsv2paymentsTokenInformation tokenInformation = new Ptsv2paymentsTokenInformation(
                PaymentInstrument: tokenInformationPaymentInstrument,
                ShippingAddress: tokenInformationShippingAddress
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                TokenInformation: tokenInformation
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
