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
    internal class MerchantBoardingCUP
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

            Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures> features = new Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures>();

            PaymentsProductsCardProcessingSubscriptionInformationFeatures obj1 = new PaymentsProductsCardProcessingSubscriptionInformationFeatures
            {
                Enabled = true
            };

            features.Add("cardNotPresent", obj1);
            features.Add("cardPresent", obj1);

            subscriptionInformation.Features = features;
            cardProcessing.SubscriptionInformation = subscriptionInformation;

            PaymentsProductsCardProcessingConfigurationInformation configurationInformation = new PaymentsProductsCardProcessingConfigurationInformation();

            CardProcessingConfig configurations = new CardProcessingConfig();
            CardProcessingConfigCommon common = new CardProcessingConfigCommon
            {
                MerchantCategoryCode = "1799"
            };

            Dictionary<string, CardProcessingConfigCommonProcessors> processors = new Dictionary<string, CardProcessingConfigCommonProcessors>();

            CardProcessingConfigCommonProcessors obj2 = new CardProcessingConfigCommonProcessors();
            CardProcessingConfigCommonAcquirer acquirer = new CardProcessingConfigCommonAcquirer
            {
                CountryCode = "344_hongkong",
                InstitutionId = "22344"
            };

            obj2.Acquirer = acquirer;

            Dictionary<string, CardProcessingConfigCommonCurrencies1> currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>();

            CardProcessingConfigCommonCurrencies1 obj3 = new CardProcessingConfigCommonCurrencies1
            {
                Enabled = true,
                EnabledCardPresent = false,
                EnabledCardNotPresent = true,
                MerchantId = "112233",
                TerminalId = "11224455",
                ServiceEnablementNumber = ""
            };

            currencies.Add("HKD", obj3);
            currencies.Add("AUD", obj3);
            currencies.Add("USD", obj3);

            obj2.Currencies = currencies;

            Dictionary<string, CardProcessingConfigCommonPaymentTypes> paymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>();

            CardProcessingConfigCommonPaymentTypes obj4 = new CardProcessingConfigCommonPaymentTypes
            {
                Enabled = true
            };

            paymentTypes.Add("CUP", obj4);
            obj2.PaymentTypes = paymentTypes;

            processors.Add("CUP", obj2);
            common.Processors = processors;
            configurations.Common = common;
            configurationInformation.Configurations = configurations;

            Guid templateId = Guid.Parse("1D8BC41A-F04E-4133-87C8-D89D1806106F");
            configurationInformation.TemplateId = templateId;
            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;

            PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation2 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //virtualTerminal.SubscriptionInformation = subscriptionInformation2;

            PaymentsProductsVirtualTerminalConfigurationInformation configurationInformation2 = new PaymentsProductsVirtualTerminalConfigurationInformation
            {
                TemplateId = Guid.Parse("9FA1BB94-5119-48D3-B2E5-A81FD3C657B5")
            };

            virtualTerminal.ConfigurationInformation = configurationInformation2;
            payments.VirtualTerminal = virtualTerminal;

            PaymentsProductsTax customerInvoicing = new PaymentsProductsTax();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation3 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //customerInvoicing.SubscriptionInformation = subscriptionInformation3;
            payments.CustomerInvoicing = customerInvoicing;
            selectedProducts.Payments = payments;

            RiskProducts risk = new RiskProducts();
            selectedProducts.Risk = risk;
            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();

            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation4 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //tokenManagement.SubscriptionInformation = subscriptionInformation4;

            CommerceSolutionsProductsTokenManagementConfigurationInformation configurationInformation3 = new CommerceSolutionsProductsTokenManagementConfigurationInformation
            {
                TemplateId = Guid.Parse("9FA1BB94-5119-48D3-B2E5-A81FD3C657B5")
            };

            tokenManagement.ConfigurationInformation = configurationInformation3;
            commerceSolutions.TokenManagement = tokenManagement;

            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();

            PaymentsProductsTax transactionSearch = new PaymentsProductsTax();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation5 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //transactionSearch.SubscriptionInformation = subscriptionInformation5;
            valueAddedServices.TransactionSearch = transactionSearch;

            PaymentsProductsTax reporting = new PaymentsProductsTax
            {
                //SubscriptionInformation = subscriptionInformation5
            };

            valueAddedServices.Reporting = reporting;
            selectedProducts.ValueAddedServices = valueAddedServices;
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
