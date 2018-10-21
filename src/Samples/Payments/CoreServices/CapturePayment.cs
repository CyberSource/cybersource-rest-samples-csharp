using System;
using System.Collections.Generic;
using AuthenticationSdk.core;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;
using Newtonsoft.Json;

namespace Cybersource_rest_samples_dotnet.Samples.Payments.CoreServices
{
    public class CapturePayment
    {
        public static InlineResponse2012 Run(IReadOnlyDictionary<string, string> configDictionary = null)
        {
            var processPaymentId = ProcessPayment.Run().Id;

            var requestObj = new CapturePaymentRequest();

            var clientReferenceInformationObj = new V2paymentsClientReferenceInformation
            {
                Code = "test_capture"
            };

            requestObj.ClientReferenceInformation = clientReferenceInformationObj;

            var pointOfSaleInformationObj = new V2paymentsidcapturesPointOfSaleInformation();

            pointOfSaleInformationObj.CardPresent = false;
            pointOfSaleInformationObj.CatLevel = "6";
            pointOfSaleInformationObj.TerminalCapability = "4";
            requestObj.PointOfSaleInformation = pointOfSaleInformationObj;

            var orderInformationObj = new V2paymentsidcapturesOrderInformation();

            var billToObj = new V2paymentsidcapturesOrderInformationBillTo
            {
                Country = "US",
                FirstName = "John",
                LastName = "Doe",
                Address1 = "1 Market St",
                PostalCode = "94105",
                Locality = "San Francisco",
                AdministrativeArea = "CA",
                Email = "test@cybs.com"
            };

            orderInformationObj.BillTo = billToObj;

            var amountDetailsObj = new V2paymentsidcapturesOrderInformationAmountDetails
            {
                TotalAmount = "102.21",
                Currency = "USD"
            };

            orderInformationObj.AmountDetails = amountDetailsObj;

            requestObj.OrderInformation = orderInformationObj;

            try
            {
                //var config = new CyberSource.Client.Configuration();
                //var config2 = CyberSource.Client.Configuration.Default;

                var apiInstance = new CaptureApi()
                {
                    Configuration = new CyberSource.Client.Configuration()
                };

                var result = apiInstance.CapturePayment(requestObj, processPaymentId);
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
