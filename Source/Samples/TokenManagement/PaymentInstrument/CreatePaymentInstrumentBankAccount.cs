using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreatePaymentInstrumentBankAccount
    {
        public static Tmsv2customersEmbeddedDefaultPaymentInstrument Run()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string bankAccountType = "savings";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentBankAccount bankAccount = new Tmsv2customersEmbeddedDefaultPaymentInstrumentBankAccount(
                Type: bankAccountType
           );

            string buyerInformationCompanyTaxID = "12345";
            string buyerInformationCurrency = "USD";
            DateTime buyerInformationDateOfBirth = Convert.ToDateTime("2000-12-13");

            List<Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List<Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationId1 = "57684432111321";
            string buyerInformationPersonalIdentificationType1 = "driver license";
            string buyerInformationPersonalIdentificationIssuedByAdministrativeArea1 = "CA";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformationIssuedBy buyerInformationPersonalIdentificationIssuedBy1 = new Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformationIssuedBy(
                AdministrativeArea: buyerInformationPersonalIdentificationIssuedByAdministrativeArea1
           );

            buyerInformationPersonalIdentification.Add(new Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformationPersonalIdentification(
                Id: buyerInformationPersonalIdentificationId1,
                Type: buyerInformationPersonalIdentificationType1,
                IssuedBy: buyerInformationPersonalIdentificationIssuedBy1
           ));

            Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformation buyerInformation = new Tmsv2customersEmbeddedDefaultPaymentInstrumentBuyerInformation(
                CompanyTaxID: buyerInformationCompanyTaxID,
                Currency: buyerInformationCurrency,
                DateOfBirth: buyerInformationDateOfBirth,
                PersonalIdentification: buyerInformationPersonalIdentification
           );

            string billToFirstName = "John";
            string billToLastName = "Doe";
            string billToCompany = "CyberSource";
            string billToAddress1 = "1 Market St";
            string billToLocality = "San Francisco";
            string billToAdministrativeArea = "CA";
            string billToPostalCode = "94105";
            string billToCountry = "US";
            string billToEmail = "test@cybs.com";
            string billToPhoneNumber = "4158880000";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentBillTo billTo = new Tmsv2customersEmbeddedDefaultPaymentInstrumentBillTo(
                FirstName: billToFirstName,
                LastName: billToLastName,
                Company: billToCompany,
                Address1: billToAddress1,
                Locality: billToLocality,
                AdministrativeArea: billToAdministrativeArea,
                PostalCode: billToPostalCode,
                Country: billToCountry,
                Email: billToEmail,
                PhoneNumber: billToPhoneNumber
           );

            string processingInformationBankTransferOptionsSeCCode = "WEB";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentProcessingInformationBankTransferOptions processingInformationBankTransferOptions = new Tmsv2customersEmbeddedDefaultPaymentInstrumentProcessingInformationBankTransferOptions(
                SECCode: processingInformationBankTransferOptionsSeCCode
           );

            Tmsv2customersEmbeddedDefaultPaymentInstrumentProcessingInformation processingInformation = new Tmsv2customersEmbeddedDefaultPaymentInstrumentProcessingInformation(
                BankTransferOptions: processingInformationBankTransferOptions
           );

            string instrumentIdentifierId = "A7A91A2CA872B272E05340588D0A0699";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier instrumentIdentifier = new Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier(
                Id: instrumentIdentifierId
           );

            var requestObj = new PostPaymentInstrumentRequest(
                BankAccount: bankAccount,
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
                Tmsv2customersEmbeddedDefaultPaymentInstrument result = apiInstance.PostPaymentInstrument(requestObj, profileid);
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
