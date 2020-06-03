using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Model;
using CyberSource.Api;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.ServiceFees
{
    public class CreditWithServiceFee
    {
        public static PtsV2CreditsPost201Response Run()
        {
            var requestObj = new CreateCreditRequest();

            var v2PaymentsClientReferenceInformationObj = new Ptsv2paymentsClientReferenceInformation
            {
                Code = "12345678"
            };

            requestObj.ClientReferenceInformation = v2PaymentsClientReferenceInformationObj;

            var v2PaymentsOrderInformationObj = new Ptsv2paymentsidrefundsOrderInformation();
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

            var v2PaymentsPaymentInformationCardObj = new Ptsv2paymentsidrefundsPaymentInformationCard
                                            {
                                                ExpirationYear = "2031",
                                                Number = "4111111111111111",
                                                ExpirationMonth = "03"
                                            };

            v2PaymentsPaymentInformationObj.Card = v2PaymentsPaymentInformationCardObj;

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
