using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class PinDebitPurchaseReversalVoid
    {
        public static PtsV2PaymentsVoidsPost201Response Run()
        {
            var id = PinDebitPurchaseUsingEMVTechnologyWithContactlessReadWithVisaPlatformConnect.Run().Id;
            string clientReferenceInformationCode = "Pin Debit Purchase Reversal(Void)";
            Ptsv2paymentsidreversalsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsidreversalsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string paymentInformationPaymentTypeName = "CARD";
            Ptsv2paymentsidrefundsPaymentInformationPaymentType paymentInformationPaymentType = new Ptsv2paymentsidrefundsPaymentInformationPaymentType(
                Name: paymentInformationPaymentTypeName
           );

            Ptsv2paymentsidvoidsPaymentInformation paymentInformation = new Ptsv2paymentsidvoidsPaymentInformation(
                PaymentType: paymentInformationPaymentType
           );

            
            string amountDetailsCurrency = "USD";
            string amountDetailsTotalAmount = "202.00";
            Ptsv2paymentsidreversalsReversalInformationAmountDetails amountDetails = new Ptsv2paymentsidreversalsReversalInformationAmountDetails(
                Currency: amountDetailsCurrency,
                TotalAmount: amountDetailsTotalAmount
                );
            Ptsv2paymentsidvoidsOrderInformation orderInformation = new Ptsv2paymentsidvoidsOrderInformation(
                AmountDetails: amountDetails);

            var requestObj = new VoidPaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
                PaymentInformation: paymentInformation,
                OrderInformation: orderInformation
           );

            try
            {
                var configDictionary = new Configuration().GetAlternativeConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new VoidApi(clientConfig);
                PtsV2PaymentsVoidsPost201Response result = apiInstance.VoidPayment(requestObj, id);
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
