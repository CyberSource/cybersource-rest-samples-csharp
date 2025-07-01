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
    internal class CreateRegistration
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
            PaymentsProductsPayerAuthentication payerAuthentication = new PaymentsProductsPayerAuthentication();
            //PaymentsProductsPayerAuthenticationSubscriptionInformation subscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation
            //{
            //Enabled = true
            //};

            //payerAuthentication.SubscriptionInformation = subscriptionInformation;

            PaymentsProductsPayerAuthenticationConfigurationInformation configurationInformation = new PaymentsProductsPayerAuthenticationConfigurationInformation();
            PayerAuthConfig configurations = new PayerAuthConfig();
            PayerAuthConfigCardTypes cardTypes = new PayerAuthConfigCardTypes();
            PayerAuthConfigCardTypesVerifiedByVisa verifiedByVisa = new PayerAuthConfigCardTypesVerifiedByVisa();
            List<PayerAuthConfigCardTypesVerifiedByVisaCurrencies> currencies = new List<PayerAuthConfigCardTypesVerifiedByVisaCurrencies>();
            PayerAuthConfigCardTypesVerifiedByVisaCurrencies currency1 = new PayerAuthConfigCardTypesVerifiedByVisaCurrencies
            {
            CurrencyCodes = new List<string> { "ALL" },
            AcquirerId = "469216",
            ProcessorMerchantId = "678855"
            };

            currencies.Add(currency1);
            verifiedByVisa.Currencies = currencies;
            cardTypes.VerifiedByVisa = verifiedByVisa;
            configurations.CardTypes = cardTypes;
            configurationInformation.Configurations = configurations;
            payerAuthentication.ConfigurationInformation = configurationInformation;
            payments.PayerAuthentication = payerAuthentication;

            PaymentsProductsCardProcessing cardProcessing = new PaymentsProductsCardProcessing();
            PaymentsProductsCardProcessingSubscriptionInformation subscriptionInformation2 = new PaymentsProductsCardProcessingSubscriptionInformation
            {
            Enabled = true,
            Features = new Dictionary<string, PaymentsProductsCardProcessingSubscriptionInformationFeatures>
            {
            { 
            "cardNotPresent", new PaymentsProductsCardProcessingSubscriptionInformationFeatures 
            { Enabled = true } }
            }
            };

            cardProcessing.SubscriptionInformation = subscriptionInformation2;

            PaymentsProductsCardProcessingConfigurationInformation configurationInformation2 = new PaymentsProductsCardProcessingConfigurationInformation();
            CardProcessingConfig configurations2 = new CardProcessingConfig();
            CardProcessingConfigCommon common = new CardProcessingConfigCommon
            {
            MerchantCategoryCode = "1234",
            MerchantDescriptorInformation = new CardProcessingConfigCommonMerchantDescriptorInformation
            {
            Name = "r4ef",
            City = "Bellevue",
            Country = "US",
            Phone = "4255547845",
            State = "WA",
            Street = "StreetName",
            Zip = "98007"
            },
            Processors = new Dictionary<string, CardProcessingConfigCommonProcessors>
            {
            {
            "tsys", new CardProcessingConfigCommonProcessors
            {
            MerchantId = "123456789101",
            TerminalId = "1231",
            IndustryCode = "D",
            VitalNumber = "71234567",
            MerchantBinNumber = "123456",
            MerchantLocationNumber = "00001",
            StoreID = "1234",
            SettlementCurrency = "USD"
            }
            }
            }
            };

            configurations2.Common = common;
            CardProcessingConfigFeatures features2 = new CardProcessingConfigFeatures();
            CardProcessingConfigFeaturesCardNotPresent cardNotPresent = new CardProcessingConfigFeaturesCardNotPresent
            {
            VisaStraightThroughProcessingOnly = true
            };

            features2.CardNotPresent = cardNotPresent;
            configurations2.Features = features2;
            configurationInformation2.Configurations = configurations2;
            cardProcessing.ConfigurationInformation = configurationInformation2;
            payments.CardProcessing = cardProcessing;

            //PaymentsProductsVirtualTerminal virtualTerminal = new PaymentsProductsVirtualTerminal
            //{
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            //};

            //payments.VirtualTerminal = virtualTerminal;

            //PaymentsProductsTax customerInvoicing = new PaymentsProductsTax
            //{
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            //};

            //payments.CustomerInvoicing = customerInvoicing;

            PaymentsProductsPayouts payouts = new PaymentsProductsPayouts
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            };

            payments.Payouts = payouts;

            selectedProducts.Payments = payments;

            CommerceSolutionsProducts commerceSolutions = new CommerceSolutionsProducts();
            CommerceSolutionsProductsTokenManagement tokenManagement = new CommerceSolutionsProductsTokenManagement
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true }
            };

            commerceSolutions.TokenManagement = tokenManagement;
            selectedProducts.CommerceSolutions = commerceSolutions;

            RiskProducts risk = new RiskProducts();
            RiskProductsFraudManagementEssentials fraudManagementEssentials = new RiskProductsFraudManagementEssentials
            {
            //SubscriptionInformation = new PaymentsProductsPayerAuthenticationSubscriptionInformation { Enabled = true },
            ConfigurationInformation = new RiskProductsFraudManagementEssentialsConfigurationInformation
            {
            TemplateId = Guid.Parse("E4EDB280-9DAC-4698-9EB9-9434D40FF60C")
            }
            };

            risk.FraudManagementEssentials = fraudManagementEssentials;
            selectedProducts.Risk = risk;

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
