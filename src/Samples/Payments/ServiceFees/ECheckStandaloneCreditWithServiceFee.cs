using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class ECheckStandaloneCreditWithServiceFee
    {
        public static PtsV2CreditsPost201Response Run()
        {
            var requestObj = new CreateCreditRequest();

            var v2PaymentsClientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation
            {
                Code = "TC46125-1"
            };
            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;
            var processingInformation = new Ptsv2creditsProcessingInformation
            {
                CommerceIndicator = "internet"
            };
            requestObj.ProcessingInformation = processingInformation;

            var v2PaymentsOrderInformationObj = new Ptsv2paymentsidrefundsOrderInformation();
            var v2paymentsOrderInformationBillToCompany = "Visa";
            var v2PaymentsOrderInformationBillToObj = new Ptsv2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "4158880000",
                Address1 = "1 Market St",
                PostalCode = "94105",
                Locality = "san francisco",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };
            v2PaymentsOrderInformationBillToObj.Company = v2paymentsOrderInformationBillToCompany;
            v2PaymentsOrderInformationObj.BillTo = v2PaymentsOrderInformationBillToObj;

            var v2PaymentsOrderInformationAmountDetailsObj = new Ptsv2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "2325.00",
                Currency = "usd",
                ServiceFeeAmount = "30.00"
            };

            v2PaymentsOrderInformationObj.AmountDetails = v2PaymentsOrderInformationAmountDetailsObj;

            requestObj.OrderInformation = v2PaymentsOrderInformationObj;

            var v2PaymentsPaymentInformationObj = new Ptsv2paymentsidrefundsPaymentInformation();
            var v2paymentsPaymentInformationBankAccountObj = new Ptsv2paymentsPaymentInformationBankAccount
            {
                Number = "4100",
                Type = "C",
                CheckNumber = "123456"
            };
            var v2paymentsPaymentInformationBankObj = new Ptsv2paymentsPaymentInformationBank
            {
                RoutingNumber = "071923284"
            };
            v2paymentsPaymentInformationBankObj.Account = v2paymentsPaymentInformationBankAccountObj;
            v2PaymentsPaymentInformationObj.Bank = v2paymentsPaymentInformationBankObj;
            requestObj.PaymentInformation = v2PaymentsPaymentInformationObj;

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);
                var apiInstance = new CreditApi(clientConfig);

                var result = apiInstance.CreateCredit(requestObj);
                Console.WriteLine(result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception on calling the API: " + e.Message);
                return null;
            }
        }
    }
}
