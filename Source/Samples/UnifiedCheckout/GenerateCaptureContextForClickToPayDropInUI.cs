using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.UnifiedCheckout
{
    public class GenerateCaptureContextForClickToPayDropInUI
    {

        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static String Run()
        {

            string clientVersion = "0.23";

            List<string> targetOrigins = new List<string>();
            targetOrigins.Add("https://yourCheckoutPage.com");

            List<string> allowedCardNetworks = new List<string>();
            allowedCardNetworks.Add("VISA");
            allowedCardNetworks.Add("MASTERCARD");
            allowedCardNetworks.Add("AMEX");
            allowedCardNetworks.Add("CARNET");
            allowedCardNetworks.Add("CARTESBANCAIRES");
            allowedCardNetworks.Add("CUP");
            allowedCardNetworks.Add("DINERSCLUB");
            allowedCardNetworks.Add("DISCOVER");
            allowedCardNetworks.Add("EFTPOS");
            allowedCardNetworks.Add("ELO");
            allowedCardNetworks.Add("JCB");
            allowedCardNetworks.Add("JCREW");
            allowedCardNetworks.Add("MADA");
            allowedCardNetworks.Add("MAESTRO");
            allowedCardNetworks.Add("MEEZA");

            List<string> allowedPaymentTypes = new List<string>();
            allowedPaymentTypes.Add("CLICKTOPAY");
            string country = "US";
            string locale = "en_US";
            string captureMandateBillingType = "FULL";
            bool captureMandateRequestEmail = true;
            bool captureMandateRequestPhone = true;
            bool captureMandateRequestShipping = true;

            List<string> captureMandateShipToCountries = new List<string>();
            captureMandateShipToCountries.Add("US");
            captureMandateShipToCountries.Add("GB");
            bool captureMandateShowAcceptedNetworkIcons = true;
            Upv1capturecontextsCaptureMandate captureMandate = new Upv1capturecontextsCaptureMandate(
                BillingType: captureMandateBillingType,
                RequestEmail: captureMandateRequestEmail,
                RequestPhone: captureMandateRequestPhone,
                RequestShipping: captureMandateRequestShipping,
                ShipToCountries: captureMandateShipToCountries,
                ShowAcceptedNetworkIcons: captureMandateShowAcceptedNetworkIcons
            );

            string orderInformationAmountDetailsTotalAmount = "21.00";
            string orderInformationAmountDetailsCurrency = "USD";
            Upv1capturecontextsOrderInformationAmountDetails orderInformationAmountDetails = new Upv1capturecontextsOrderInformationAmountDetails(
                TotalAmount: orderInformationAmountDetailsTotalAmount,
                Currency: orderInformationAmountDetailsCurrency
            );

            Upv1capturecontextsOrderInformation orderInformation = new Upv1capturecontextsOrderInformation(
                AmountDetails: orderInformationAmountDetails
            );

            var requestObj = new GenerateUnifiedCheckoutCaptureContextRequest(
                ClientVersion: clientVersion,
                TargetOrigins: targetOrigins,
                AllowedCardNetworks: allowedCardNetworks,
                AllowedPaymentTypes: allowedPaymentTypes,
                Country: country,
                Locale: locale,
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
                WriteLogAudit(apiInstance.GetStatusCode());
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
