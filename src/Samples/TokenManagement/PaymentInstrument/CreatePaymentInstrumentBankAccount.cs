using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreatePaymentInstrumentBankAccount
    {
        public static TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedPaymentInstruments Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string bankAccountType = "savings";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBankAccount bankAccount = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBankAccount(
                Type: bankAccountType
           );

            string buyerInformationCompanyTaxID = "12345";
            string buyerInformationCurrency = "USD";
            string buyerInformationDateOfBirth = "2000-12-13";

            List <TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List <TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationId1 = "57684432111321";
            string buyerInformationPersonalIdentificationType1 = "driver license";
            string buyerInformationPersonalIdentificationIssuedByAdministrativeArea1 = "CA";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformationIssuedBy buyerInformationPersonalIdentificationIssuedBy1 = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformationIssuedBy(
                AdministrativeArea: buyerInformationPersonalIdentificationIssuedByAdministrativeArea1
           );

            buyerInformationPersonalIdentification.Add(new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformationPersonalIdentification(
                Id: buyerInformationPersonalIdentificationId1,
                Type: buyerInformationPersonalIdentificationType1,
                IssuedBy: buyerInformationPersonalIdentificationIssuedBy1
           ));

            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformation buyerInformation = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedBuyerInformation(
                CompanyTaxID: buyerInformationCompanyTaxID,
                Currency: buyerInformationCurrency,
                DateOfBirth: buyerInformationDateOfBirth,
                PersonalIdentification: buyerInformationPersonalIdentification
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
            string processingInformationBankTransferOptionsSeCCode = "WEB";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformationBankTransferOptions processingInformationBankTransferOptions = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformationBankTransferOptions(
                SECCode: processingInformationBankTransferOptionsSeCCode
           );

            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformation processingInformation = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedProcessingInformation(
                BillPaymentProgramEnabled: processingInformationBillPaymentProgramEnabled,
                BankTransferOptions: processingInformationBankTransferOptions
           );

            string merchantInformationMerchantDescriptorAlternateName = "Branch Name";
            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedMerchantInformationMerchantDescriptor merchantInformationMerchantDescriptor = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedMerchantInformationMerchantDescriptor(
                AlternateName: merchantInformationMerchantDescriptorAlternateName
           );

            TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedMerchantInformation merchantInformation = new TmsV1InstrumentIdentifiersPaymentInstrumentsGet200ResponseEmbeddedMerchantInformation(
                MerchantDescriptor: merchantInformationMerchantDescriptor
           );

            string instrumentIdentifierBankAccountNumber = "4100";
            string instrumentIdentifierBankAccountRoutingNumber = "071923284";
            Tmsv1instrumentidentifiersBankAccount instrumentIdentifierBankAccount = new Tmsv1instrumentidentifiersBankAccount(
                Number: instrumentIdentifierBankAccountNumber,
                RoutingNumber: instrumentIdentifierBankAccountRoutingNumber
           );

            Tmsv1paymentinstrumentsInstrumentIdentifier instrumentIdentifier = new Tmsv1paymentinstrumentsInstrumentIdentifier(
                BankAccount: instrumentIdentifierBankAccount
           );

            var requestObj = new CreatePaymentInstrumentRequest(
                BankAccount: bankAccount,
                BuyerInformation: buyerInformation,
                BillTo: billTo,
                ProcessingInformation: processingInformation,
                MerchantInformation: merchantInformation,
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
