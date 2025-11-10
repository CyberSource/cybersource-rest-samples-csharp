using System;
using System.Collections.Generic;
using System.Globalization;

using CyberSource.Api;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.UnifiedCheckout
{
    public class GenerateUnifiedCheckoutCaptureContextPassingBillingShipping
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
            allowedPaymentTypes.Add("APPLEPAY");
            allowedPaymentTypes.Add("CHECK");
            allowedPaymentTypes.Add("CLICKTOPAY");
            allowedPaymentTypes.Add("GOOGLEPAY");
            allowedPaymentTypes.Add("PANENTRY");
            allowedPaymentTypes.Add("PAZE");
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

            string orderInformationBillToAddress1 = "277 Park Avenue";
            string orderInformationBillToAddress2 = "50th Floor";
            string orderInformationBillToAddress3 = "Desk NY-50110";
            string orderInformationBillToAddress4 = "address4";
            string orderInformationBillToAdministrativeArea = "NY";
            string orderInformationBillToBuildingNumber = "buildingNumber";
            string orderInformationBillToCountry = "US";
            string orderInformationBillToDistrict = "district";
            string orderInformationBillToLocality = "New York";
            string orderInformationBillToPostalCode = "10172";
            string orderInformationBillToCompanyName = "Visa Inc";
            string orderInformationBillToCompanyAddress1 = "900 Metro Center Blvd";
            string orderInformationBillToCompanyAddress2 = "address2";
            string orderInformationBillToCompanyAddress3 = "address3";
            string orderInformationBillToCompanyAddress4 = "address4";
            string orderInformationBillToCompanyAdministrativeArea = "CA";
            string orderInformationBillToCompanyBuildingNumber = "1";
            string orderInformationBillToCompanyCountry = "US";
            string orderInformationBillToCompanyDistrict = "district";
            string orderInformationBillToCompanyLocality = "Foster City";
            string orderInformationBillToCompanyPostalCode = "94404";
            Upv1capturecontextsDataOrderInformationBillToCompany orderInformationBillToCompany = new Upv1capturecontextsDataOrderInformationBillToCompany(
                Name: orderInformationBillToCompanyName,
                Address1: orderInformationBillToCompanyAddress1,
                Address2: orderInformationBillToCompanyAddress2,
                Address3: orderInformationBillToCompanyAddress3,
                Address4: orderInformationBillToCompanyAddress4,
                AdministrativeArea: orderInformationBillToCompanyAdministrativeArea,
                BuildingNumber: orderInformationBillToCompanyBuildingNumber,
                Country: orderInformationBillToCompanyCountry,
                District: orderInformationBillToCompanyDistrict,
                Locality: orderInformationBillToCompanyLocality,
                PostalCode: orderInformationBillToCompanyPostalCode
            );

            string orderInformationBillToEmail = "john.doe@visa.com";
            string orderInformationBillToFirstName = "John";
            string orderInformationBillToLastName = "Doe";
            string orderInformationBillToMiddleName = "F";
            string orderInformationBillToNameSuffix = "Jr";
            string orderInformationBillToTitle = "Mr";
            string orderInformationBillToPhoneNumber = "1234567890";
            string orderInformationBillToPhoneType = "phoneType";
            Upv1capturecontextsDataOrderInformationBillTo orderInformationBillTo = new Upv1capturecontextsDataOrderInformationBillTo(
                Address1: orderInformationBillToAddress1,
                Address2: orderInformationBillToAddress2,
                Address3: orderInformationBillToAddress3,
                Address4: orderInformationBillToAddress4,
                AdministrativeArea: orderInformationBillToAdministrativeArea,
                BuildingNumber: orderInformationBillToBuildingNumber,
                Country: orderInformationBillToCountry,
                District: orderInformationBillToDistrict,
                Locality: orderInformationBillToLocality,
                PostalCode: orderInformationBillToPostalCode,
                Company: orderInformationBillToCompany,
                Email: orderInformationBillToEmail,
                FirstName: orderInformationBillToFirstName,
                LastName: orderInformationBillToLastName,
                MiddleName: orderInformationBillToMiddleName,
                NameSuffix: orderInformationBillToNameSuffix,
                Title: orderInformationBillToTitle,
                PhoneNumber: orderInformationBillToPhoneNumber,
                PhoneType: orderInformationBillToPhoneType
            );

            string orderInformationShipToAddress1 = "CyberSource";
            string orderInformationShipToAddress2 = "Victoria House";
            string orderInformationShipToAddress3 = "15-17 Gloucester Street";
            string orderInformationShipToAddress4 = "string";
            string orderInformationShipToAdministrativeArea = "CA";
            string orderInformationShipToBuildingNumber = "string";
            string orderInformationShipToCountry = "GB";
            string orderInformationShipToDistrict = "string";
            string orderInformationShipToLocality = "Belfast";
            string orderInformationShipToPostalCode = "BT1 4LS";
            string orderInformationShipToFirstName = "Joe";
            string orderInformationShipToLastName = "Soap";
            Upv1capturecontextsDataOrderInformationShipTo orderInformationShipTo = new Upv1capturecontextsDataOrderInformationShipTo(
                Address1: orderInformationShipToAddress1,
                Address2: orderInformationShipToAddress2,
                Address3: orderInformationShipToAddress3,
                Address4: orderInformationShipToAddress4,
                AdministrativeArea: orderInformationShipToAdministrativeArea,
                BuildingNumber: orderInformationShipToBuildingNumber,
                Country: orderInformationShipToCountry,
                District: orderInformationShipToDistrict,
                Locality: orderInformationShipToLocality,
                PostalCode: orderInformationShipToPostalCode,
                FirstName: orderInformationShipToFirstName,
                LastName: orderInformationShipToLastName
            );

            Upv1capturecontextsOrderInformation orderInformation = new Upv1capturecontextsOrderInformation(
                AmountDetails: orderInformationAmountDetails,
                BillTo: orderInformationBillTo,
                ShipTo: orderInformationShipTo
            );

            Upv1capturecontextsCompleteMandate completeMandate = new Upv1capturecontextsCompleteMandate(
                Type: "CAPTURE",
                DecisionManager: false
                
            );

            var requestObj = new GenerateUnifiedCheckoutCaptureContextRequest(
                ClientVersion: clientVersion,
                TargetOrigins: targetOrigins,
                AllowedCardNetworks: allowedCardNetworks,
                AllowedPaymentTypes: allowedPaymentTypes,
                Country: country,
                Locale: locale,
                CaptureMandate: captureMandate,
                OrderInformation: orderInformation,
                CompleteMandate: completeMandate
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
