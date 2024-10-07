using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.UnifiedCheckout
{
    public class GenerateUnifiedCheckout
    {
        public static String Run()
        {

            Upv1capturecontextsCaptureMandate captureMandate = new Upv1capturecontextsCaptureMandate(
                BillingType: "FULL",
                RequestEmail:true,
                RequestPhone:true,
                RequestShipping:true,
                ShipToCountries: new List<string>(){"US","GB" },
                ShowAcceptedNetworkIcons: true
            );
            Upv1capturecontextsOrderInformationAmountDetails amountDetails= new Upv1capturecontextsOrderInformationAmountDetails(
                TotalAmount: "21.00",
                Currency: "USD"
            );
            Upv1capturecontextsOrderInformation orderInformation = new Upv1capturecontextsOrderInformation(
                AmountDetails: amountDetails
            );

            var requestObj = new GenerateUnifiedCheckoutCaptureContextRequest(
                TargetOrigins: new List<string>() { "https://the-up-demo.appspot.com" },
                ClientVersion: "0.15",
                AllowedCardNetworks: new List<string>() {  "VISA","MASTERCARD", "AMEX" },
                AllowedPaymentTypes: new List<string>() { "PANENTRY","SRC" },
                Country : "US",
                Locale: "en_US",
                CaptureMandate: captureMandate,
                OrderInformation: orderInformation
            );

            try
            {
                var configDictionary = new Configuration().GetConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new UnifiedCheckoutCaptureContextApi(clientConfig);
                String result = apiInstance.GenerateUnifiedCheckoutCaptureContext(requestObj);
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
