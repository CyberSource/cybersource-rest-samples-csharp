using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class AuthorizationUsingBluefinPCIP2PEWithVisaPlatformConnect
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "demomerchant";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            bool processingInformationCapture = false;
            string processingInformationCommerceIndicator = "retail";
            bool processingInformationAuthorizationOptionsPartialAuthIndicator = true;
            bool processingInformationAuthorizationOptionsIgnoreAvsResult = true;
            bool processingInformationAuthorizationOptionsIgnoreCvResult = true;
            Ptsv2paymentsProcessingInformationAuthorizationOptions processingInformationAuthorizationOptions = new Ptsv2paymentsProcessingInformationAuthorizationOptions(
                PartialAuthIndicator: processingInformationAuthorizationOptionsPartialAuthIndicator,
                IgnoreAvsResult: processingInformationAuthorizationOptionsIgnoreAvsResult,
                IgnoreCvResult: processingInformationAuthorizationOptionsIgnoreCvResult
           );

            Ptsv2paymentsProcessingInformation processingInformation = new Ptsv2paymentsProcessingInformation(
                Capture: processingInformationCapture,
                CommerceIndicator: processingInformationCommerceIndicator,
                AuthorizationOptions: processingInformationAuthorizationOptions
           );

            string paymentInformationCardExpirationMonth = "12";
            string paymentInformationCardExpirationYear = "2050";
            Ptsv2paymentsPaymentInformationCard paymentInformationCard = new Ptsv2paymentsPaymentInformationCard(
                ExpirationMonth: paymentInformationCardExpirationMonth,
                ExpirationYear: paymentInformationCardExpirationYear
           );

            string paymentInformationFluidDataDescriptor = "Ymx1ZWZpbg==";
            string paymentInformationFluidDataValue = "02d700801f3c20008383252a363031312a2a2a2a2a2a2a2a303030395e46444d53202020202020202020202020202020202020202020205e323231322a2a2a2a2a2a2a2a3f2a3b363031312a2a2a2a2a2a2a2a303030393d323231322a2a2a2a2a2a2a2a3f2a7a75ad15d25217290c54b3d9d1c3868602136c68d339d52d98423391f3e631511d548fff08b414feac9ff6c6dede8fb09bae870e4e32f6f462d6a75fa0a178c3bd18d0d3ade21bc7a0ea687a2eef64551751e502d97cb98dc53ea55162cdfa395431323439323830303762994901000001a000731a8003";
            Ptsv2paymentsPaymentInformationFluidData paymentInformationFluidData = new Ptsv2paymentsPaymentInformationFluidData(
                Descriptor: paymentInformationFluidDataDescriptor,
                Value: paymentInformationFluidDataValue
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Card: paymentInformationCard,
                FluidData: paymentInformationFluidData
           );

            string orderInformationAmountDetailsTotalAmount = "100.00";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Deo";
            string orderInformationBillToAddress1 = "201 S. Division St.";
            string orderInformationBillToLocality = "Ann Arbor";
            string orderInformationBillToAdministrativeArea = "MI";
            string orderInformationBillToPostalCode = "48104-2201";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToDistrict = "MI";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "999999999";
            Ptsv2paymentsOrderInformationBillTo orderInformationBillTo = new Ptsv2paymentsOrderInformationBillTo(
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                Address1: orderInformationBillToAddress1,
                Locality: orderInformationBillToLocality,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                PostalCode: orderInformationBillToPostalCode,
                Country: orderInformationBillToCountry,
                District: orderInformationBillToDistrict,
                Email: orderInformationBillToEmail,
                PhoneNumber: orderInformationBillToPhoneNumber
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo
           );

            int pointOfSaleInformationCatLevel = 1;
            string pointOfSaleInformationEntryMode = "keyed";
            int pointOfSaleInformationTerminalCapability = 2;
            Ptsv2paymentsPointOfSaleInformation pointOfSaleInformation = new Ptsv2paymentsPointOfSaleInformation(
                CatLevel: pointOfSaleInformationCatLevel,
                EntryMode: pointOfSaleInformationEntryMode,
                TerminalCapability: pointOfSaleInformationTerminalCapability
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation,
                PointOfSaleInformation: pointOfSaleInformation
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
