using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class AuthorizationWithCustomerPaymentInstrumentAndShippingAddressTokenId
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationCustomerId = "AB695DA801DD1BB6E05341588E0A3BDC";
            Ptsv2paymentsPaymentInformationCustomer paymentInformationCustomer = new Ptsv2paymentsPaymentInformationCustomer(
                Id: paymentInformationCustomerId
           );

            string paymentInformationPaymentInstrumentId = "AB6A54B982A6FCB6E05341588E0A3935";
            Ptsv2paymentsPaymentInformationPaymentInstrument paymentInformationPaymentInstrument = new Ptsv2paymentsPaymentInformationPaymentInstrument(
                Id: paymentInformationPaymentInstrumentId
           );

            string paymentInformationShippingAddressId = "AB6A54B97C00FCB6E05341588E0A3935";
            Ptsv2paymentsPaymentInformationShippingAddress paymentInformationShippingAddress = new Ptsv2paymentsPaymentInformationShippingAddress(
                Id: paymentInformationShippingAddressId
           );

            Ptsv2paymentsPaymentInformation paymentInformation = new Ptsv2paymentsPaymentInformation(
                Customer: paymentInformationCustomer,
                PaymentInstrument: paymentInformationPaymentInstrument,
                ShippingAddress: paymentInformationShippingAddress
           );

            string orderInformationAmountDetailsTotalAmount = "102.21";
            string orderInformationAmountDetailsCurrency = "USD";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            Ptsv2paymentsOrderInformation orderInformation = new Ptsv2paymentsOrderInformation(
                AmountDetails: orderInformationAmountDetails
           );

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
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
