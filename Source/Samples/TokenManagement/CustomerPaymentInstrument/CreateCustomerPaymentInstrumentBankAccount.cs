using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreateCustomerPaymentInstrumentBankAccount
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static PostCustomerPaymentInstrumentRequest Run()
        {
            string customerTokenId = "AB695DA801DD1BB6E05341588E0A3BDC";
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
            TmsPaymentInstrumentProcessingInfoBankTransferOptions processingInformationBankTransferOptions = new TmsPaymentInstrumentProcessingInfoBankTransferOptions(
                SECCode: processingInformationBankTransferOptionsSeCCode
           );

            TmsPaymentInstrumentProcessingInfo processingInformation = new TmsPaymentInstrumentProcessingInfo(
                BankTransferOptions: processingInformationBankTransferOptions
           );

            string instrumentIdentifierId = "A7A91A2CA872B272E05340588D0A0699";
            Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier instrumentIdentifier = new Tmsv2customersEmbeddedDefaultPaymentInstrumentInstrumentIdentifier(
                Id: instrumentIdentifierId
           );

            var requestObj = new PostCustomerPaymentInstrumentRequest(
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

                var apiInstance = new CustomerPaymentInstrumentApi(clientConfig);
                PostCustomerPaymentInstrumentRequest result = apiInstance.PostCustomerPaymentInstrument(customerTokenId, requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}
