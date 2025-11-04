using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSource.Api;
using CyberSource.Client;
using CyberSource.Model;

namespace Cybersource_rest_samples_dotnet.Samples.MerchantBoarding
{
    internal class MerchantBoardingFDIGlobal
    {



        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static InlineResponse2013 Run()
        {

            PostRegistrationBody reqObj = new PostRegistrationBody();

            Boardingv1registrationsOrganizationInformation organizationInformation = new Boardingv1registrationsOrganizationInformation
            {
            ParentOrganizationId = "apitester00",
            Type = "MERCHANT",
            Configurable = true
            };

            Boardingv1registrationsOrganizationInformationBusinessInformation businessInformation = new Boardingv1registrationsOrganizationInformationBusinessInformation
            {
            Name = "StuartWickedFastEatz"
            };

            Boardingv1registrationsOrganizationInformationBusinessInformationAddress address = new Boardingv1registrationsOrganizationInformationBusinessInformationAddress
            {
            Country = "US",
            Address1 = "123456 SandMarket",
            Locality = "ORMOND BEACH",
            AdministrativeArea = "FL",
            PostalCode = "32176"
            };

            businessInformation.Address = address;
            businessInformation.WebsiteUrl = "https://www.StuartWickedEats.com";
            businessInformation.PhoneNumber = "6574567813";

            Boardingv1registrationsOrganizationInformationBusinessInformationBusinessContact businessContact = new Boardingv1registrationsOrganizationInformationBusinessInformationBusinessContact
            {
            FirstName = "Stuart",
            LastName = "Stuart",
            PhoneNumber = "6574567813",
            Email = "svc_email_bt@corpdev.visa.com"
            };

            businessInformation.BusinessContact = businessContact;
            businessInformation.MerchantCategoryCode = "5999";
            organizationInformation.BusinessInformation = businessInformation;

            reqObj.OrganizationInformation = organizationInformation;

            Boardingv1registrationsProductInformation productInformation = new Boardingv1registrationsProductInformation();
            Boardingv1registrationsProductInformationSelectedProducts selectedProducts = new Boardingv1registrationsProductInformationSelectedProducts();

            PaymentsProducts payments = new PaymentsProducts();
            PaymentsProductsCardProcessing cardProcessing = new PaymentsProductsCardProcessing();
            PaymentsProductsCardProcessingSubscriptionInformation subscriptionInformation = new PaymentsProductsCardProcessingSubscriptionInformation
            {
            Enabled = true
            };

            var features = new Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures>
            {
            { "cardNotPresent", new PaymentsProductsCardProcessingSubscriptionInformationFeatures { Enabled = true } },
            { "cardPresent", new PaymentsProductsCardProcessingSubscriptionInformationFeatures { Enabled = true } }
            };

            subscriptionInformation.Features = features;
            cardProcessing.SubscriptionInformation = subscriptionInformation;

            PaymentsProductsCardProcessingConfigurationInformation configurationInformation = new PaymentsProductsCardProcessingConfigurationInformation();

            CardProcessingConfig configurations = new CardProcessingConfig();
            CardProcessingConfigCommon common = new CardProcessingConfigCommon
            {
            MerchantCategoryCode = "0742",
            DefaultAuthTypeCode = "PRE",
            ProcessLevel3Data = "ignored",
            MasterCardAssignedId = "123456789",
            EnablePartialAuth = true
            };

            var processors = new Dictionary<string, CardProcessingConfigCommonProcessors>();
            CardProcessingConfigCommonProcessors obj5 = new CardProcessingConfigCommonProcessors
            {
            Acquirer = new CardProcessingConfigCommonAcquirer()
            };

            var currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>
            {
            { "CHF", new CardProcessingConfigCommonCurrencies1 { Enabled = true, EnabledCardPresent = false, EnabledCardNotPresent = true, MerchantId = "123456789mer", TerminalId = "12345ter", ServiceEnablementNumber = "" } },
            { "HRK", new CardProcessingConfigCommonCurrencies1 { Enabled = true, EnabledCardPresent = false, EnabledCardNotPresent = true, MerchantId = "123456789mer", TerminalId = "12345ter", ServiceEnablementNumber = "" } },
            { "ERN", new CardProcessingConfigCommonCurrencies1 { Enabled = true, EnabledCardPresent = false, EnabledCardNotPresent = true, MerchantId = "123456789mer", TerminalId = "12345ter", ServiceEnablementNumber = "" } },
            { "USD", new CardProcessingConfigCommonCurrencies1 { Enabled = true, EnabledCardPresent = false, EnabledCardNotPresent = true, MerchantId = "123456789mer", TerminalId = "12345ter", ServiceEnablementNumber = "" } }
            };

            obj5.Currencies = currencies;

            var paymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>
            {
            { "MASTERCARD", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "DISCOVER", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "JCB", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "VISA", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "AMERICAN_EXPRESS", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "DINERS_CLUB", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "CUP", new CardProcessingConfigCommonPaymentTypes { Enabled = true } }
            };

            var currencies2 = new Dictionary<string, CardProcessingConfigCommonCurrencies>
            {
            { "USD", new CardProcessingConfigCommonCurrencies { Enabled = true, TerminalId = "pint123", MerchantId = "pinm123", ServiceEnablementNumber = null } }
            };

            paymentTypes.Add("PIN_DEBIT", new CardProcessingConfigCommonPaymentTypes { Enabled = true, Currencies = currencies2 });

            obj5.PaymentTypes = paymentTypes;
            obj5.BatchGroup = "fdiglobal_vme_default";
            obj5.EnhancedData = "disabled";
            obj5.EnablePosNetworkSwitching = true;
            obj5.EnableTransactionReferenceNumber = true;

            processors["fdiglobal"] = obj5;

            common.Processors = processors;
            configurations.Common = common;

            CardProcessingConfigFeatures features2 = new CardProcessingConfigFeatures();
            CardProcessingConfigFeaturesCardNotPresent cardNotPresent = new CardProcessingConfigFeaturesCardNotPresent();

            var processors3 = new Dictionary<string, CardProcessingConfigFeaturesCardNotPresentProcessors>
            {
            { "fdiglobal", new CardProcessingConfigFeaturesCardNotPresentProcessors
            {
            RelaxAddressVerificationSystem = true,
            RelaxAddressVerificationSystemAllowExpiredCard = true,
            RelaxAddressVerificationSystemAllowZipWithoutCountry = true
            }
            }
            };

            cardNotPresent.Processors = processors3;
            cardNotPresent.VisaStraightThroughProcessingOnly = true;
            cardNotPresent.AmexTransactionAdviceAddendum1 = "amex12345";
            cardNotPresent.IgnoreAddressVerificationSystem = true;

            features2.CardNotPresent = cardNotPresent;
            configurations.Features = features2;
            configurationInformation.Configurations = configurations;

            string templateId = "685A1FC9-3CEC-454C-9D8A-19205529CE45";
            configurationInformation.TemplateId = templateId;

            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;
            selectedProducts.Payments = payments;

            productInformation.SelectedProducts = selectedProducts;
            reqObj.ProductInformation = productInformation;



            try
            {
                var configDictionary = new MerchantBoardingConfiguration().GetMerchantBoardingConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MerchantBoardingApi(clientConfig);
                InlineResponse2013 result = apiInstance.PostRegistration(reqObj);
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
