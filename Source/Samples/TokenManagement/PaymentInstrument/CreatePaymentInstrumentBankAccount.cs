using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.TokenManagement
{
    public class CreatePaymentInstrumentBankAccount
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static async System.Threading.Tasks.Task<PostPaymentInstrumentRequest> RunAsync()
        {
            var profileid = "93B32398-AD51-4CC2-A682-EA3E93614EB1";

            string bankAccountType = "savings";
            DefaultPaymentInstrumentBankAccount bankAccount = new DefaultPaymentInstrumentBankAccount(
                Type: bankAccountType
           );

            string buyerInformationCompanyTaxID = "12345";
            string buyerInformationCurrency = "USD";
            DateTime buyerInformationDateOfBirth = Convert.ToDateTime("2000-12-13");

            List<DefaultPaymentInstrumentBuyerInformationPersonalIdentification> buyerInformationPersonalIdentification = new List<DefaultPaymentInstrumentBuyerInformationPersonalIdentification>();
            string buyerInformationPersonalIdentificationId1 = "57684432111321";
            string buyerInformationPersonalIdentificationType1 = "driver license";
            string buyerInformationPersonalIdentificationIssuedByAdministrativeArea1 = "CA";
            DefaultPaymentInstrumentBuyerInformationIssuedBy buyerInformationPersonalIdentificationIssuedBy1 = new DefaultPaymentInstrumentBuyerInformationIssuedBy(
                AdministrativeArea: buyerInformationPersonalIdentificationIssuedByAdministrativeArea1
           );

            buyerInformationPersonalIdentification.Add(new DefaultPaymentInstrumentBuyerInformationPersonalIdentification(
                Id: buyerInformationPersonalIdentificationId1,
                Type: buyerInformationPersonalIdentificationType1,
                IssuedBy: buyerInformationPersonalIdentificationIssuedBy1
           ));

            DefaultPaymentInstrumentBuyerInformation buyerInformation = new DefaultPaymentInstrumentBuyerInformation(
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
            DefaultPaymentInstrumentBillTo billTo = new DefaultPaymentInstrumentBillTo(
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
            DefaultPaymentInstrumentInstrumentIdentifier instrumentIdentifier = new DefaultPaymentInstrumentInstrumentIdentifier(
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
                PostPaymentInstrumentRequest result = await apiInstance.PostPaymentInstrumentAsync(requestObj, profileid);
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
