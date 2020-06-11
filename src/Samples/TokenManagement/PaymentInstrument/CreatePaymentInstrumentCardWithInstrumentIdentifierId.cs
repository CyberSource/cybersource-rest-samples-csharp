using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreatePaymentInstrumentCardWithInstrumentIdentifierId
    {
        public static TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedPaymentInstruments Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string cardExpirationMonth = "09";
            string cardExpirationYear = "2017";
            string cardType = "visa";
            string cardIssueNumber = "01";
            string cardStartMonth = "01";
            string cardStartYear = "2016";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedCard card = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedCard(
                ExpirationMonth: cardExpirationMonth,
                ExpirationYear: cardExpirationYear,
                Type: cardType,
                IssueNumber: cardIssueNumber,
                StartMonth: cardStartMonth,
                StartYear: cardStartYear
           );

            string buyerInformationCompanyTaxID = "12345";
            string buyerInformationCurrency = "USD";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformation buyerInformation = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformation(
                CompanyTaxID: buyerInformationCompanyTaxID,
                Currency: buyerInformationCurrency
           );

            string billToFirstName = "John";
            string billToLastName = "Smith";
            string billToCompany = "Cybersource";
            string billToAddress1 = "8310 Capital of Texas Highwas North";
            string billToAddress2 = "Bluffstone Drive";
            string billToLocality = "Austin";
            string billToAdministrativeArea = "TX";
            string billToPostalCode = "78731";
            string billToCountry = "US";
            string billToEmail = "john.smith@test.com";
            string billToPhoneNumber = "+44 2890447951";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBillTo billTo = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBillTo(
                FirstName: billToFirstName,
                LastName: billToLastName,
                Company: billToCompany,
                Address1: billToAddress1,
                Address2: billToAddress2,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry,
                Email: billToEmail,
                PhoneNumber: billToPhoneNumber
           );

            bool processingInformationBillPaymentProgramEnabled = true;
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformation processingInformation = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformation(
                BillPaymentProgramEnabled: processingInformationBillPaymentProgramEnabled
           );

            string instrumentIdentifierId = "7020000000001061135";
            Tmsv1paymentinstrumentsInstrumentIdentifier instrumentIdentifier = new Tmsv1paymentinstrumentsInstrumentIdentifier(
                Id: instrumentIdentifierId
           );

            var requestObj = new CreatePaymentInstrumentRequest(
                Card: card,
                BuyerInformation: buyerInformation,
                BillTo: billTo,
                ProcessingInformation: processingInformation,
                InstrumentIdentifier: instrumentIdentifier
           );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new PaymentInstrumentApi(clientConfig);
                TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedPaymentInstruments result = apiInstance.CreatePaymentInstrument(profileid, requestObj);
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
