using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments
{
    public class AuthorizationWithInstrumentIdentifierTokenId
    {
        public static PtsV2PaymentsPost201Response Run()
        {
            string clientReferenceInformationCode = "TC50171_3";
            Ptsv2paymentsClientReferenceInformation clientReferenceInformation = new Ptsv2paymentsClientReferenceInformation(
                Code: clientReferenceInformationCode
           );

            string orderInformationAmountDetailsTotalAmount = "200";
            string orderInformationAmountDetailsCurrency = "usd";
            Ptsv2paymentsOrderInformationAmountDetails orderInformationAmountDetails = new Ptsv2paymentsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
           );

            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Deo";
            string orderInformationBillToAddress1 = "900 Metro Center Blvd";
            string orderInformationBillToLocality = "Foster City";
            string orderInformationBillToAdministrativeArea = "CA";
            string orderInformationBillToPostalCode = "48104-2201";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToEmail = "test@cybs.com";
            string orderInformationBillToPhoneNumber = "9321499232";
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

            var requestObj = new CreatePaymentRequest(
                ClientReferenceInformation: clientReferenceInformation,
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
