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
    internal class MerchantBoardingAmexDirect
    {

        public static void WriteLogAudit(int status)
        {
            var filePath = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString().Split('.');
            var filename = filePath[filePath.Length - 1];
            Console.WriteLine($"[Sample Code Testing] [{filename}] {status}");
        }


        public static InlineResponse2012 Run()
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
            PaymentsProductsCardProcessingSubscriptionInformation subscriptionInformation = new PaymentsProductsCardProcessingSubscriptionInformation();

            subscriptionInformation.Enabled = true;
            var features = new Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures>();

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
            CardProcessingConfigCommonMerchantDescriptorInformation merchantDescriptorInformation = new CardProcessingConfigCommonMerchantDescriptorInformation
            {
                City = "Cupertino",
                Country = "USA",
                Name = "Mer name",
                Phone = "8885554444",
                Zip = "94043",
                State = "CA",
                Street = "mer street",
                Url = "www.test.com"
            };

            common.MerchantDescriptorInformation = merchantDescriptorInformation;
            common.SubMerchantId = "123457";
            common.SubMerchantBusinessName = "bus name";

            var processors = new Dictionary<string, CardProcessingConfigCommonProcessors>();
            CardProcessingConfigCommonProcessors obj2 = new CardProcessingConfigCommonProcessors();
            CardProcessingConfigCommonAcquirer acquirer = new CardProcessingConfigCommonAcquirer();

            obj2.Acquirer = acquirer;
            var currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>();
            CardProcessingConfigCommonCurrencies1 obj3 = new CardProcessingConfigCommonCurrencies1
            {
                Enabled = true,
                EnabledCardPresent = true,
                TerminalId = "",
                ServiceEnablementNumber = "1234567890"
            };
            currencies.Add("AED", obj3);
            currencies.Add("FJD", obj3);
            currencies.Add("USD", obj3);

            obj2.Currencies = currencies;

            var paymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>();
            CardProcessingConfigCommonPaymentTypes obj4 = new CardProcessingConfigCommonPaymentTypes
            {
                Enabled = true
            };
            paymentTypes.Add("AMERICAN_EXPRESS", obj4);

            obj2.PaymentTypes = paymentTypes;
            obj2.AllowMultipleBills = false;
            obj2.AvsFormat = "basic";
            obj2.BatchGroup = "amexdirect_vme_default";
            obj2.EnableAutoAuthReversalAfterVoid = false;
            obj2.EnhancedData = "disabled";
            obj2.EnableLevel2 = false;
            obj2.AmexTransactionAdviceAddendum1 = "amex123";
            processors.Add("acquirer", obj2);

            common.Processors = processors;
            configurations.Common = common;

            CardProcessingConfigFeatures features2 = new CardProcessingConfigFeatures();
            CardProcessingConfigFeaturesCardNotPresent cardNotPresent = new CardProcessingConfigFeaturesCardNotPresent();

            var processors3 = new Dictionary<string, CardProcessingConfigFeaturesCardNotPresentProcessors>();
            CardProcessingConfigFeaturesCardNotPresentProcessors obj5 = new CardProcessingConfigFeaturesCardNotPresentProcessors
            {
                RelaxAddressVerificationSystem = true,
                RelaxAddressVerificationSystemAllowExpiredCard = true,
                RelaxAddressVerificationSystemAllowZipWithoutCountry = false
            };
            processors3.Add("amexdirect", obj5);

            cardNotPresent.Processors = processors3;
            features2.CardNotPresent = cardNotPresent;
            configurations.Features = features2;
            configurationInformation.Configurations = configurations;
            Guid templateId = Guid.Parse("2B80A3C7-5A39-4CC3-9882-AC4A828D3646");
            configurationInformation.TemplateId = templateId;
            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;

            PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal();
            PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation2 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            {
                Enabled = true
            };
            virtualTerminal.SubscriptionInformation = subscriptionInformation2;

            PaymentsProductsVirtualTerminalConfigurationInformation configurationInformation3 = new PaymentsProductsVirtualTerminalConfigurationInformation();
            Guid templateId2 = Guid.Parse("9FA1BB94-5119-48D3-B2E5-A81FD3C657B5");
            configurationInformation3.TemplateId = templateId2;
            virtualTerminal.ConfigurationInformation = configurationInformation3;
            payments.VirtualTerminal = virtualTerminal;

            PaymentsProductsTax customerInvoicing = new PaymentsProductsTax();
            PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation6 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            {
                Enabled = true
            };
            customerInvoicing.SubscriptionInformation = subscriptionInformation6;
            payments.CustomerInvoicing = customerInvoicing;
            selectedProducts.Payments = payments;

            RiskProducts risk = new RiskProducts();
            selectedProducts.Risk = risk;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();
            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement();

            PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation7 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            {
                Enabled = true
            };
            tokenManagement.SubscriptionInformation = subscriptionInformation7;
            CommerceSolutionsProductsTokenManagementConfigurationInformation configurationInformation4 = new CommerceSolutionsProductsTokenManagementConfigurationInformation();
            Guid templateId3 = Guid.Parse("D62BEE20-DCFD-4AA2-8723-BA3725958ABA");
            configurationInformation4.TemplateId = templateId3;
            tokenManagement.ConfigurationInformation = configurationInformation4;
            commerceSolutions.TokenManagement = tokenManagement;
            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();
            PaymentsProductsTax transactionSearch = new PaymentsProductsTax();
            PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation8 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            {
                Enabled = true
            };
            transactionSearch.SubscriptionInformation = subscriptionInformation8;

            valueAddedServices.TransactionSearch = transactionSearch;
            PaymentsProductsTax reporting = new PaymentsProductsTax();
            PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation9 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            {
                Enabled = true
            };
            reporting.SubscriptionInformation = subscriptionInformation9;
            valueAddedServices.Reporting = reporting;

            selectedProducts.ValueAddedServices = valueAddedServices;
            productInformation.SelectedProducts = selectedProducts;
            reqObj.ProductInformation = productInformation;

            try
            {
                var configDictionary = new MerchantBoardingConfiguration().GetMerchantBoardingConfiguration();
                var clientConfig = new CyberSource.Client.Configuration(merchConfigDictObj: configDictionary);

                var apiInstance = new MerchantBoardingApi(clientConfig);
                InlineResponse2012 result = apiInstance.PostRegistration(reqObj);
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
