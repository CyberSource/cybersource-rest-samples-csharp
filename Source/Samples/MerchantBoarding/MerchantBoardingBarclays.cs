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
    internal class MerchantBoardingBarclays
    {


        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }

        public static InlineResponse2014 Run()
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
            MerchantCategoryCode = "5999",
            DefaultAuthTypeCode = "FINAL"
            };

            var processors = new Dictionary<string, CardProcessingConfigCommonProcessors>();

            CardProcessingConfigCommonProcessors obj2 = new CardProcessingConfigCommonProcessors
            {
            Acquirer = new CardProcessingConfigCommonAcquirer()
            };

            var currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>
            {
            { "AED", new CardProcessingConfigCommonCurrencies1
            {
            Enabled = true,
            EnabledCardPresent = false,
            EnabledCardNotPresent = true,
            MerchantId = "1234",
            ServiceEnablementNumber = "",
            TerminalIds = new List<string> { "12351245" }
            }
            },
            { "USD", new CardProcessingConfigCommonCurrencies1
            {
            Enabled = true,
            EnabledCardPresent = false,
            EnabledCardNotPresent = true,
            MerchantId = "1234",
            ServiceEnablementNumber = "",
            TerminalIds = new List<string> { "12351245" }
            }
            }
            };

            obj2.Currencies = currencies;

            var paymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>
            {
            { "MASTERCARD", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "VISA", new CardProcessingConfigCommonPaymentTypes { Enabled = true } }
            };

            obj2.PaymentTypes = paymentTypes;
            obj2.BatchGroup = "barclays2_16";
            obj2.QuasiCash = false;
            obj2.EnhancedData = "disabled";
            obj2.MerchantId = "124555";
            obj2.EnableMultiCurrencyProcessing = "false";

            processors["barclays2"] = obj2;

            common.Processors = processors;
            configurations.Common = common;

            CardProcessingConfigFeatures features3 = new CardProcessingConfigFeatures();

            CardProcessingConfigFeaturesCardNotPresent cardNotPresent = new CardProcessingConfigFeaturesCardNotPresent();

            var processors4 = new Dictionary<string, CardProcessingConfigFeaturesCardNotPresentProcessors>
            {
            { "barclays2", new CardProcessingConfigFeaturesCardNotPresentProcessors
            {
            Payouts = new CardProcessingConfigFeaturesCardNotPresentPayouts
            {
            MerchantId = "1233",
            TerminalId = "1244"
            }
            }
            }
            };

            cardNotPresent.Processors = processors4;
            features3.CardNotPresent = cardNotPresent;

            configurations.Features = features3;

            configurationInformation.Configurations = configurations;

            string templateId = "0A413572-1995-483C-9F48-FCBE4D0B2E86";
            configurationInformation.TemplateId = templateId;
            cardProcessing.ConfigurationInformation = configurationInformation;

            payments.CardProcessing = cardProcessing;

            PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal();

            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation2 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //virtualTerminal.SubscriptionInformation = subscriptionInformation2;

            PaymentsProductsVirtualTerminalConfigurationInformation configurationInformation2 = new PaymentsProductsVirtualTerminalConfigurationInformation
            {
            TemplateId = "E4EDB280-9DAC-4698-9EB9-9434D40FF60C"
            };

            virtualTerminal.ConfigurationInformation = configurationInformation2;
            payments.VirtualTerminal = virtualTerminal;

            PaymentsProductsTax customerInvoicing = new PaymentsProductsTax();

            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation3 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //customerInvoicing.SubscriptionInformation = subscriptionInformation3;
            payments.CustomerInvoicing = customerInvoicing;

            selectedProducts.Payments = payments;

            RiskProducts risk2 = new RiskProducts();
            selectedProducts.Risk = risk2;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();
            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement();

            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation5 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //tokenManagement.SubscriptionInformation = subscriptionInformation5;

            CommerceSolutionsProductsTokenManagementConfigurationInformation configurationInformation5 = new CommerceSolutionsProductsTokenManagementConfigurationInformation
            {
            TemplateId = "D62BEE20-DCFD-4AA2-8723-BA3725958ABA"
            };

            tokenManagement.ConfigurationInformation = configurationInformation5;
            commerceSolutions.TokenManagement = tokenManagement;
            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();

            PaymentsProductsTax transactionSearch = new PaymentsProductsTax();

            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation6 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //transactionSearch.SubscriptionInformation = subscriptionInformation6;
            valueAddedServices.TransactionSearch = transactionSearch;

            PaymentsProductsTax reporting = new PaymentsProductsTax();

            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation7 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //reporting.SubscriptionInformation = subscriptionInformation7;
            valueAddedServices.Reporting = reporting;
            selectedProducts.ValueAddedServices = valueAddedServices;

            productInformation.SelectedProducts = selectedProducts;
            reqObj.ProductInformation = productInformation;



            try
            {
                var configDictionary = new MerchantBoardingConfiguration().GetMerchantBoardingConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MerchantBoardingApi(clientConfig);
                InlineResponse2014 result = apiInstance.PostRegistration(reqObj);
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
