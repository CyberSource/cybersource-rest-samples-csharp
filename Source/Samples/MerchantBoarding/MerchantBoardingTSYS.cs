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
    internal class MerchantBoardingTSYS
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
            features["cardNotPresent"] = obj1;
            features["cardPresent"] = obj1;
            subscriptionInformation.Features = features;
            cardProcessing.SubscriptionInformation = subscriptionInformation;

            PaymentsProductsCardProcessingConfigurationInformation configurationInformation = new PaymentsProductsCardProcessingConfigurationInformation();

            CardProcessingConfig configurations = new CardProcessingConfig();
            CardProcessingConfigCommon common = new CardProcessingConfigCommon
            {
                MerchantCategoryCode = "5999",
                ProcessLevel3Data = "ignored",
                DefaultAuthTypeCode = "FINAL",
                EnablePartialAuth = false,
                AmexVendorCode = "2233"
            };

            CardProcessingConfigCommonMerchantDescriptorInformation merchantDescriptorInformation = new CardProcessingConfigCommonMerchantDescriptorInformation
            {
                City = "cupertino",
                Country = "USA",
                Name = "kumar",
                State = "CA",
                Phone = "888555333",
                Zip = "94043",
                Street = "steet1"
            };

            common.MerchantDescriptorInformation = merchantDescriptorInformation;

            var processors = new Dictionary<string, CardProcessingConfigCommonProcessors>();
            CardProcessingConfigCommonProcessors obj5 = new CardProcessingConfigCommonProcessors
            {
                Acquirer = new CardProcessingConfigCommonAcquirer()
            };

            var currencies = new Dictionary<string, CardProcessingConfigCommonCurrencies1>();
            CardProcessingConfigCommonCurrencies1 obj6 = new CardProcessingConfigCommonCurrencies1
            {
                Enabled = true,
                EnabledCardPresent = true,
                EnabledCardNotPresent = true,
                TerminalId = "1234",
                ServiceEnablementNumber = ""
            };

            currencies["CAD"] = obj6;
            obj5.Currencies = currencies;

            var paymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>();
            CardProcessingConfigCommonPaymentTypes obj7 = new CardProcessingConfigCommonPaymentTypes
            {
                Enabled = true
            };

            paymentTypes["MASTERCARD"] = obj7;
            paymentTypes["VISA"] = obj7;

            obj5.PaymentTypes = paymentTypes;

            obj5.BankNumber = "234576";
            obj5.ChainNumber = "223344";
            obj5.BatchGroup = "vital_1130";
            obj5.EnhancedData = "disabled";
            obj5.IndustryCode = "D";
            obj5.MerchantBinNumber = "765576";
            obj5.MerchantId = "834215123456";
            obj5.MerchantLocationNumber = "00001";
            obj5.StoreID = "2563";
            obj5.VitalNumber = "71234567";
            obj5.QuasiCash = false;
            obj5.SendAmexLevel2Data = null;
            obj5.SoftDescriptorType = "1 - trans_ref_no";
            obj5.TravelAgencyCode = "2356";
            obj5.TravelAgencyName = "Agent";

            processors["tsys"] = obj5;
            common.Processors = processors;

            configurations.Common = common;

            CardProcessingConfigFeatures features2 = new CardProcessingConfigFeatures();
            CardProcessingConfigFeaturesCardNotPresent cardNotPresent = new CardProcessingConfigFeaturesCardNotPresent
            {
                VisaStraightThroughProcessingOnly = false,
                AmexTransactionAdviceAddendum1 = null
            };

            features2.CardNotPresent = cardNotPresent;

            configurations.Features = features2;
            configurationInformation.Configurations = configurations;
            configurationInformation.TemplateId = new Guid("818048AD-2860-4D2D-BC39-2447654628A1");

            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;

            PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation5 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //virtualTerminal.SubscriptionInformation = subscriptionInformation5;

            PaymentsProductsVirtualTerminalConfigurationInformation configurationInformation5 = new PaymentsProductsVirtualTerminalConfigurationInformation
            {
                TemplateId = new Guid("9FA1BB94-5119-48D3-B2E5-A81FD3C657B5")
            };

            virtualTerminal.ConfigurationInformation = configurationInformation5;
            payments.VirtualTerminal = virtualTerminal;

            PaymentsProductsTax customerInvoicing = new PaymentsProductsTax();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation6 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //customerInvoicing.SubscriptionInformation = subscriptionInformation6;
            payments.CustomerInvoicing = customerInvoicing;

            selectedProducts.Payments = payments;

            RiskProducts risk = new RiskProducts();
            selectedProducts.Risk = risk;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();
            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation7 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //tokenManagement.SubscriptionInformation = subscriptionInformation7;

            CommerceSolutionsProductsTokenManagementConfigurationInformation configurationInformation7 = new CommerceSolutionsProductsTokenManagementConfigurationInformation
            {
                TemplateId = new Guid("D62BEE20-DCFD-4AA2-8723-BA3725958ABA")
            };

            tokenManagement.ConfigurationInformation = configurationInformation7;
            commerceSolutions.TokenManagement = tokenManagement;
            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();

            PaymentsProductsTax transactionSearch = new PaymentsProductsTax();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation9 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //transactionSearch.SubscriptionInformation = subscriptionInformation9;
            valueAddedServices.TransactionSearch = transactionSearch;

            PaymentsProductsTax reporting = new PaymentsProductsTax();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation3 = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //    Enabled = true
            //};

            //reporting.SubscriptionInformation = subscriptionInformation3;
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
