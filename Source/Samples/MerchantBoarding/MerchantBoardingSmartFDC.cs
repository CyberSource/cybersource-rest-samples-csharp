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
    internal class MerchantBoardingSmartFDC
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
            MerchantCategoryCode = "1799",
            DefaultAuthTypeCode = "FINAL",
            EnablePartialAuth = true
            };

            var processors = new Dictionary<string, CardProcessingConfigCommonProcessors>
            {
            {
            "smartfdc", new CardProcessingConfigCommonProcessors
            {
            Acquirer = new CardProcessingConfigCommonAcquirer(),
            PaymentTypes = new Dictionary<string, CardProcessingConfigCommonPaymentTypes>
            {
            { "MASTERCARD", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "DISCOVER", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "JCB", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "VISA", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "DINERS_CLUB", new CardProcessingConfigCommonPaymentTypes { Enabled = true } },
            { "AMERICAN_EXPRESS", new CardProcessingConfigCommonPaymentTypes { Enabled = true } }
            },
            BatchGroup = "smartfdc_00",
            MerchantId = "00001234567",
            TerminalId = "00007654321"
            }
            }
            };

            common.Processors = processors;
            configurations.Common = common;
            configurationInformation.Configurations = configurations;

            configurationInformation.TemplateId = Guid.Parse("3173DA78-A71E-405B-B79C-928C1A9C6AB2");
            cardProcessing.ConfigurationInformation = configurationInformation;
            payments.CardProcessing = cardProcessing;

            PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true },
            ConfigurationInformation = new PaymentsProductsVirtualTerminalConfigurationInformation { TemplateId = Guid.Parse("9FA1BB94-5119-48D3-B2E5-A81FD3C657B5") }
            };

            payments.VirtualTerminal = virtualTerminal;

            PaymentsProductsTax customerInvoicing = new PaymentsProductsTax
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            };

            payments.CustomerInvoicing = customerInvoicing;
            selectedProducts.Payments = payments;

            RiskProducts risk = new RiskProducts();
            selectedProducts.Risk = risk;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();

            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true },
            ConfigurationInformation = new CommerceSolutionsProductsTokenManagementConfigurationInformation { TemplateId = Guid.Parse("D62BEE20-DCFD-4AA2-8723-BA3725958ABA") }
            };

            commerceSolutions.TokenManagement = tokenManagement;
            selectedProducts.CommerceSolutions = commerceSolutions;

            ValueAddedServicesProducts valueAddedServices = new ValueAddedServicesProducts();

            PaymentsProductsTax transactionSearch = new PaymentsProductsTax
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            };

            valueAddedServices.TransactionSearch = transactionSearch;

            PaymentsProductsTax reporting = new PaymentsProductsTax
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
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
