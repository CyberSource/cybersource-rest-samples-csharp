using System;
using System.Collections.Generic;
using System.Globalization;
using ApiSdk.model;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.VisaBankAccountValidation
{
    public class BankAccountValidation
    {
        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static InlineResponse20013 Run()
        {
            string clientReferenceInformationCode = "TC50171_100";
            Bavsv1accountvalidationsClientReferenceInformation clientReferenceInformation = new Bavsv1accountvalidationsClientReferenceInformation(
                Code: clientReferenceInformationCode
            );

            int processingInformationValidationLevel = 1;
            Bavsv1accountvalidationsProcessingInformation processingInformation = new Bavsv1accountvalidationsProcessingInformation(
                ValidationLevel: processingInformationValidationLevel
            );

            string paymentInformationBankRoutingNumber = "041210163";
            string paymentInformationBankAccountNumber = "99970";
            Bavsv1accountvalidationsPaymentInformationBankAccount paymentInformationBankAccount = new Bavsv1accountvalidationsPaymentInformationBankAccount(
                Number: paymentInformationBankAccountNumber
            );

            Bavsv1accountvalidationsPaymentInformationBank paymentInformationBank = new Bavsv1accountvalidationsPaymentInformationBank(
                RoutingNumber: paymentInformationBankRoutingNumber,
                Account: paymentInformationBankAccount
            );

            Bavsv1accountvalidationsPaymentInformation paymentInformation = new Bavsv1accountvalidationsPaymentInformation(
                Bank: paymentInformationBank
            );

            var requestObj = new AccountValidationsRequest(
                ClientReferenceInformation: clientReferenceInformation,
                ProcessingInformation: processingInformation,
                PaymentInformation: paymentInformation
            );

            try
            {
                var configDictionary = new BankAccountValidationConfiguration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new BankAccountValidationApi(clientConfig);
                InlineResponse20013 result = apiInstance.BankAccountValidationRequest(requestObj);
                Console.WriteLine(result);
                WriteLogAudit(apiInstance.GetStatusCode());
                return result;
            }
            catch (ApiException e)
            {
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.Message);
                Console.WriteLine("Exception on calling the API : " + e.Message);
                WriteLogAudit(e.ErrorCode);
                return null;
            }
        }
    }
}